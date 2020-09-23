using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using demo_crawler_api;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using demo_crawler_api.Models;
using System;

namespace demo_crawler_integration_test
{
    public class StatusAPITest
    {
        private readonly TestServer _server;

        private readonly HttpClient _client;

        public StatusAPITest()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());

            _client = _server.CreateClient();
        }

        [Fact]
        public async Task GetCrawlerStatus()
        {
            // Act
            var response = await _client.GetAsync("/api/status");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetCrawlerStatusUpAndRunning()
        {
            // Act
            var response = await _client.GetAsync("/api/status");
            var content = await response.Content.ReadAsStringAsync();
            var statusDto = JsonConvert.DeserializeObject<CrawlerStatusDto>(content);

            // Assert
            Assert.NotNull(statusDto);
            Assert.True(string.Equals("up and running", statusDto.Status, StringComparison.OrdinalIgnoreCase));
        }

        [Fact]
        public async Task GetResourceNotFound()
        {
            // Act
            var response = await _client.GetAsync("/api/nonexistentresource");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


    }
}
