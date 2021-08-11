using System;
using System.Text.Json.Serialization;

namespace IPAPI.JSONClasses
{
    public class RDAP
    {
        [JsonPropertyName("rdapConformance")]
        public string[] RdapConformance { get; set; }
        [JsonPropertyName("notices")]
        public Notice[] notices { get; set; }
        [JsonPropertyName("handle")]
        public string handle { get; set; }
        [JsonPropertyName("startAddress")]
        public string startAddress { get; set; }
        [JsonPropertyName("endAddress")]
        public string endAddress { get; set; }
        [JsonPropertyName("ipVersion")]
        public string ipVersion { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("type")]
        public string type { get; set; }
        [JsonPropertyName("parentHandle")]
        public string parentHandle { get; set; }
        [JsonPropertyName("events")]
        public Event[] events { get; set; }
        [JsonPropertyName("links")]
        public Link[] links { get; set; }
        [JsonPropertyName("entities")]
        public Entity[] entities { get; set; }
        [JsonPropertyName("port43")]
        public string port43 { get; set; }
        [JsonPropertyName("status")]
        public string[] status { get; set; }
        [JsonPropertyName("objectClassName")]
        public string objectClassName { get; set; }
        [JsonPropertyName("cidr0_cidrs")]
        public Cidr0_Cidrs[] cidr0_cidrs { get; set; }
        [JsonPropertyName("arin_originas0_originautnums")]
        public object[] arin_originas0_originautnums { get; set; }
    }

    public class Notice
    {
        [JsonPropertyName("title")]
        public string title { get; set; }
        [JsonPropertyName("description")]
        public string[] description { get; set; }
        [JsonPropertyName("links")]
        public Link[] links { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("value")]
        public string value { get; set; }
        [JsonPropertyName("rel")]
        public string rel { get; set; }
        [JsonPropertyName("type")]
        public string type { get; set; }
        [JsonPropertyName("href")]
        public string href { get; set; }
    }

    public class Event
    {
        [JsonPropertyName("eventAction")]
        public string eventAction { get; set; }
        [JsonPropertyName("eventDate")]
        public DateTime eventDate { get; set; }
    }

    public class Entity
    {
        [JsonPropertyName("handle")]
        public string handle { get; set; }
        [JsonPropertyName("vcardArray")]
        public object[] vcardArray { get; set; }
        [JsonPropertyName("roles")]
        public string[] roles { get; set; }
        [JsonPropertyName("links")]
        public Link[] links { get; set; }
        [JsonPropertyName("events")]
        public Event[] events { get; set; }
        [JsonPropertyName("entities")]
        public Entity[] entities { get; set; }
        [JsonPropertyName("port43")]
        public string port43 { get; set; }
        [JsonPropertyName("objectClassName")]
        public string objectClassName { get; set; }
    }

    public class Remark
    {
        [JsonPropertyName("title")]
        public string title { get; set; }
        [JsonPropertyName("description")]
        public string[] description { get; set; }
    }

    public class Cidr0_Cidrs
    {
        [JsonPropertyName("v4prefix")]
        public string v4prefix { get; set; }
        [JsonPropertyName("length")]
        public int length { get; set; }
    }

}
