
namespace demo_crawler_api.Models
{
    public class CrawlerPageResultDto
    {
        public PageResult.Root PageResult { get; set; }
        public byte[] FullPageScreenshot { get; set; }
    }
}
