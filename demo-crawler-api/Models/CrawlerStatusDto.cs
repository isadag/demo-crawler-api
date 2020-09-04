using System;
using Newtonsoft.Json;

namespace demo_crawler_api.Models
{
    public class CrawlerStatusDto
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
