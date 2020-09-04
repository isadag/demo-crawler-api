using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demo_crawler_api.Services;

namespace demo_crawler_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrawlerStatusController : ControllerBase
    {
        private readonly ICrawlerService _crawlerService;

        public CrawlerStatusController(ICrawlerService crawlerService)
        {
            _crawlerService = crawlerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var crawlerStatus = await _crawlerService.GetStatus();

            return Ok(crawlerStatus);
        }
    }
}
