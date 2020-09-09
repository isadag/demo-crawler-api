using System.Threading.Tasks;
using demo_crawler_api.Models;

namespace demo_crawler_api.Services
{
    public interface ICrawlerService
    {
        Task<CrawlerStatusDto> GetStatus();
        Task<CrawlerPageResultDto> GetPageResults(string url, bool fetchPageResults);
    }
}
