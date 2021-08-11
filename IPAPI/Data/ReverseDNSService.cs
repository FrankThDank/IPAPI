using IPAPI.JSONClasses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IPAPI.Data
{
    public class ReverseDNSService
    {
        IConfiguration config { get; }

        public ReverseDNSService(IConfiguration configuration)
        {
            config = configuration;
        }
        private async Task<ReverseDNS> GetJSONFromURL(string url)
        {
            var handler = new HttpClientHandler();
            handler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;

            using var httpClient = new HttpClient(handler);
            var response = await httpClient.GetAsync(new Uri(url));

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ReverseDNS>(responseStream);
        }

        public async Task<ReverseDNS> GetJSONFromAPI(string ipordomain = "127.0.0.1")
        {
            return await GetJSONFromURL("https://api.viewdns.info/reversedns/?ip=" + ipordomain + "&apikey=" + config.GetValue<string>("DNSAPI:Key") + "&output=json");
        }
    }
}
