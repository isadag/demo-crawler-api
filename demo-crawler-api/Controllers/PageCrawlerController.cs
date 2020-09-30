using System.Threading.Tasks;
using demo_crawler_api.Models;
using demo_crawler_api.Services;
using demo_crawler_api.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_crawler_api.Controllers
{
    [Route("api/page-crawler")]
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
            if (!UrlValidator.ValidateUrl(url))
            {
                ModelState.AddModelError("url", "Please provide a proper url");
                return BadRequest(ModelState);
            }
            
            var pageResult = await _crawlerService.GetPageResults(url);

            //TODO: add proper error handling. Would make sense to return bad request for bad URLs, internal server errors for others.
            if (pageResult == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ruh roh, something bad happened");
            }
            
            return Ok(pageResult);
        }
    }
}
