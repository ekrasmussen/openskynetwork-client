using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient.APIAccess
{
    public abstract class Connection : IDisposable
    {
        const string baseurl = "opensky-network.org/api/";

        readonly HttpClient client;
        readonly JsonSerializer serializer;

        protected bool HasCredentials => client.DefaultRequestHeaders.Authorization != null;


        protected Connection()
        {
            client = new HttpClient(new HttpClientHandler());
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://" + baseurl);

            serializer = new JsonSerializer();
        }

        protected Connection(string username, string password)
            : this()
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
        }


        protected async Task<TResult> GetAsync<TResult>(string uriPath, CancellationToken token = default)
        {
            var response = await client.GetAsync(uriPath, HttpCompletionOption.ResponseHeadersRead, token).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var sr = new StreamReader(stream))
                using (var jtr = new JsonTextReader(sr))
                {
                    return serializer.Deserialize<TResult>(jtr);
                }
            }

            throw new OpenSkyNetException($"{ response.StatusCode } - {response.ReasonPhrase}");
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void OnDispose()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                OnDispose();

                client?.Dispose();
            }
        }
    }
}
