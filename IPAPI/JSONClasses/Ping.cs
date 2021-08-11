using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IPAPI.JSONClasses
{
    public class Ping
    {
        [JsonPropertyName("query")]
        public PingQuery Query { get; set; }
        [JsonPropertyName("response")]
        public PingResponse Response { get; set; }
    }

    public class PingQuery
    {
        [JsonPropertyName("tool")]
        public string Tool { get; set; }
        [JsonPropertyName("host")]
        public string Host { get; set; }
    }

    public class PingResponse
    {
        [JsonPropertyName("replys")]
        public PingReply[] Replys { get; set; }
    }

    public class PingReply
    {
        [JsonPropertyName("rtt")]
        public string Rtt { get; set; }
    }

}
