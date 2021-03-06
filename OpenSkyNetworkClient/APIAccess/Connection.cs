using Newtonsoft.Json;
using System.Net.Http.Headers;

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

            return default(TResult);
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
