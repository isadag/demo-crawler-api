using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using demo_crawler_api;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using demo_crawler_api.Models;
using System.Text;

namespace demo_crawler_integration_test
{
    public class PageCrawlerTest
    {
        private readonly TestServer _server;

        private readonly HttpClient _client;

        public PageCrawlerTest()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _client = _server.CreateClient();
        }

        [Theory]
        [InlineData("https://www.google.com")]
        [InlineData("https://www.svt.se")]
        [InlineData("https://www.twitter.com")]
        public async Task GetScreenshotForValidUrl(string url)
        {
            // Act
            var requestUrl = $"/api/page-crawler?url={url}";
            var response = await _client.GetAsync(requestUrl);
            var content = await response.Content.ReadAsStringAsync();
            var pageResultDto = JsonConvert.DeserializeObject<CrawlerPageResultDto>(content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(pageResultDto?.FullPageScreenshot);
        }

        [Theory]
        [InlineData("https://www.sdkjhaslkjdh.asdjaksjh")]
        [InlineData("https://www.qweqwe.qweqwe")]
        public async Task GetErrorMessageForNonExistingSites(string url)
        {
            // Act
            var requestUrl = $"/api/page-crawler?url={url}";
            var response = await _client.GetAsync(requestUrl);
            var content = await response.Content.ReadAsStringAsync();
            
            // Assert
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.True(string.Equals("ruh roh, something bad happened", content, StringComparison.OrdinalIgnoreCase));           
        }
    }
}
