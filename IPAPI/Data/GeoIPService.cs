using IPAPI.JSONClasses;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IPAPI.Data
{
    public class GeoIPService
    {
        IConfiguration config { get; }

        public GeoIPService(IConfiguration configuration)
        {
            config = configuration;
        }
        private async Task<GeoIP> GetJSONFromURL(string url)
        {
            var handler = new HttpClientHandler();
            handler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;

            using var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync(new Uri(url));

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<GeoIP>(responseStream);
        }

        public async Task<GeoIP> GetJSONFromAPI(string ipordomain = "127.0.0.1")
        {
            return await GetJSONFromURL("http://ip-api.com/json/" + ipordomain);
        }
    }
}
