using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Threading.Tasks;
using IPAPI.JSONClasses;

namespace IPAPI.Data
{
    public class PingService
    {
        IConfiguration config { get; }

        public PingService(IConfiguration configuration)
        {
            config = configuration;
        }
        private async Task<JSONClasses.Ping> GetJSONFromURL(string url)
        {
            var handler = new HttpClientHandler();
            handler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;

            using var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync(new Uri(url));

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<JSONClasses.Ping>(responseStream);
        }

        public async Task<JSONClasses.Ping> GetJSONFromAPI(string ipordomain = "127.0.0.1")
        {
            return await GetJSONFromURL("https://api.viewdns.info/ping/?host=" + ipordomain + "&apikey=" + config.GetValue<string>("DNSAPI:Key") + "&output=json");
        }
    }
}
