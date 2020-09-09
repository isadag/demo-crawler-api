using System;
using Newtonsoft.Json;

namespace demo_crawler_api.Models
{
    public class PageResult
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Accessibility
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("manualDescription")]
            public string ManualDescription { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("score")]
            public double Score { get; set; }
        }

        public class BestPractices
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("score")]
            public double Score { get; set; }
        }

        public class Performance
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("score")]
            public double Score { get; set; }
        }

        public class Seo
        {
            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("manualDescription")]
            public string ManualDescription { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("score")]
            public double Score { get; set; }
        }

        public class Root
        {
            [JsonProperty("accessibility")]
            public Accessibility Accessibility { get; set; }

            [JsonProperty("best-practices")]
            public BestPractices BestPractices { get; set; }

            [JsonProperty("performance")]
            public Performance Performance { get; set; }

            [JsonProperty("seo")]
            public Seo Seo { get; set; }
        }


    }
}
