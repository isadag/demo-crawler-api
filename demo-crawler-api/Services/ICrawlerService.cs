using System;
using System.Threading.Tasks;
using demo_crawler_api.Models;

namespace demo_crawler_api.Services
{
    public interface ICrawlerService
    {
        Task<CrawlerStatusDto> GetStatus();
        Task<byte[]> GetScreenshot(string url);
    }
}
