using System;
using System.Threading.Tasks;
using System.Net.Http;
using demo_crawler_api.Models;
using Newtonsoft.Json;

namespace demo_crawler_api.Services
{
    public class CrawlerService : ICrawlerService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://demo-crawler.herokuapp.com";

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

                var content = await httpResponse.Content.ReadAsStringAsync();
                var status = JsonConvert.DeserializeObject<CrawlerStatusDto>(content);

                
                return status;
            }            
            catch (Exception ex)
            {
                // TODO: Add logging and handling
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<CrawlerPageResultDto> GetPageResults(string url)
        {
            try
            {
                var httpResponse = await _httpClient.GetAsync($"{BaseUrl}/screenshot?url={url}");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await httpResponse.Content.ReadAsByteArrayAsync();                

                return new CrawlerPageResultDto()
                {
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
