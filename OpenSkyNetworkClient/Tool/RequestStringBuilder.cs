namespace OpenSkyNetworkClient.Tool
{
    static class RequestStringBuilder
    {
        public static string CreateIcao24(Dictionary<string, object> dict)
        {
            string query = string.Empty;

            if (dict != null && dict.Count > 0)
            {
                query += "?";

                foreach (var key in dict.Keys)
                {
                    query += $"{key}={dict[key]}&";
                }

                query.TrimEnd('&');
            }

            return query;
        }

        public static string CreateIcao24(string[] icaos)
        {
            string query = "?";

            foreach (string icao in icaos)
            {
                query += $"icao24={icao}&";
            }

            query.TrimEnd('&');

            return query;
        }

        public static string CreateCallsign(string callsign)
        {
            string query = $"?callsign={callsign}";
            return query;
        }
    }
}
