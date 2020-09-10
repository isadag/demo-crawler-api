using System.Threading.Tasks;
using demo_crawler_api.Models;
using demo_crawler_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace demo_crawler_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageCrawlerController : ControllerBase
    {
        private readonly ICrawlerService _crawlerService;

        public PageCrawlerController(ICrawlerService crawlerService)
        {
            _crawlerService = crawlerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string url, bool fetchPageResults = false)
        {            
            var pageResult = await _crawlerService.GetPageResults(url, fetchPageResults);

            var apiResponse = new APIResponseBaseModel
            {
                Result = pageResult,
                Success = true
            };
            return Ok(apiResponse);
        }
    }
}
