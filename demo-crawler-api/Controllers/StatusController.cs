using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using demo_crawler_api.Services;

namespace demo_crawler_api.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ICrawlerService _crawlerService;

        public StatusController(ICrawlerService crawlerService)
        {
            _crawlerService = crawlerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var crawlerStatus = await _crawlerService.GetStatus();                
                return Ok(crawlerStatus);
            }
            catch (Exception)
            {
                //TODO: log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Ruh roh, something bad happened");
            }
            
        }
    }
}
