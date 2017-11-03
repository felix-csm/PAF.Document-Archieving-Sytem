using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAF.DAS.Service.Interfaces;
using PAF.DAS.Service.Model;
using System;

namespace PAF.DAS.WebAPI.Controllers
{
    [Authorize]
    [Route("api/paperstatistics")]
    public class PaperStatisticsController : Controller
    {
        private readonly IPaperStatisticsService _paperStatisticsService;

        public PaperStatisticsController(IPaperStatisticsService paperStatisticsService)
        {
            _paperStatisticsService = paperStatisticsService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _paperStatisticsService.GetAll();
            return Ok(result);
        }

        [HttpPost, Route("viewed")]
        public IActionResult PutViewed([FromBody]PaperStatistic value)
        {
            var result = _paperStatisticsService.AddViewed(value);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error on updating Paper Viewed statistics");
            }
        }
        [HttpPost, Route("downloaded")]
        public IActionResult PutDownloaded([FromBody]PaperStatistic value)
        {
            var result = _paperStatisticsService.AddDownloaded(value);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error on updating Paper Downloaded statistics");
            }
        }
    }
}
