using System.Text.Json.Serialization;

namespace IPAPI.JSONClasses
{
    public class ReverseDNS
    {
        [JsonPropertyName("query")]
        public Query query { get; set; }
        [JsonPropertyName("response")]
        public Response response { get; set; }
    }

    public class Query
    {
        [JsonPropertyName("tool")]
        public string tool { get; set; }
        [JsonPropertyName("ip")]
        public string ip { get; set; }
    }

    public class Response
    {
        [JsonPropertyName("rdns")]
        public string rdns { get; set; }
    }

    public class Reply
    {
        [JsonPropertyName("rtt")]
        public string rtt { get; set; }
    }

}
