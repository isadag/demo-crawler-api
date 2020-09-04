using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_crawler_api.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Get(string url)
        {            
            var crawlerStatus = await _crawlerService.GetScreenshot(url);

            return File(crawlerStatus, "image/png");
        }
    }
}
