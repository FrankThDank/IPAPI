using System.Text.Json.Serialization;

namespace IPAPI.JSONClasses
{
    public class IPConfluence
    {
        [JsonPropertyName("geoip")]
        public GeoIP GeoIP { get; set; }
        [JsonPropertyName("rdap")]
        public RDAP RDAP { get; set; }
        [JsonPropertyName("reverseDNS")]
        public ReverseDNS ReverseDNS { get; set; }
        [JsonPropertyName("ping")]
        public Ping Ping { get; set; }
    }
}
