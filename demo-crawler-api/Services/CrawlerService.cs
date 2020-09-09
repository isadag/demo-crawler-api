using System;
using System.Threading.Tasks;
using System.Net.Http;
using demo_crawler_api.Models;
using System.Text.Json;
using static demo_crawler_api.Models.PageResult;

namespace demo_crawler_api.Services
{
    public class CrawlerService : ICrawlerService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://demo-crawler.herokuapp.com";

        public CrawlerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CrawlerStatusDto> GetStatus()
        {
            try
            {
                var httpResponse = await _httpClient.GetAsync(BaseUrl);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot get status");
                }
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var content = await httpResponse.Content.ReadAsStringAsync();
                var status = JsonSerializer.Deserialize<CrawlerStatusDto>(content, options);

                
                return status;
            }            
            catch (Exception ex)
            {
                // TODO: Add logging and handling
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<CrawlerPageResultDto> GetPageResults(string url, bool fetchPageResults = false)
        {
            try
            {
                Root pageResult = null;
                var httpResponse = await _httpClient.GetAsync($"{BaseUrl}/screenshot?url={url}");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot get screenshot");
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                var content = await httpResponse.Content.ReadAsByteArrayAsync();
                //var status = JsonSerializer.Deserialize<CrawlerScreenshotResultDto>(content, options);
                if (fetchPageResults)
                {
                    var pageResultResponse = await _httpClient.GetAsync($"{BaseUrl}/pageresult?url={url}");
                    var pageResultContent = await pageResultResponse.Content.ReadAsStreamAsync();
                    pageResult = await JsonSerializer.DeserializeAsync<Root>(pageResultContent, options);
                }

                return new CrawlerPageResultDto()
                {
                    PageResult = pageResult,
                    FullPageScreenshot = content
                };
            }
            catch (Exception ex)
            {
                // TODO: Add logging and handling
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
