using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PAF.DAS.Service.Interfaces;
using PAF.DAS.Service.Model;
using Microsoft.Extensions.Logging;

namespace PAF.DAS.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/papers")]
    public class PapersController : Controller
    {
        private readonly IPaperService _paperService;

        public PapersController(IPaperService paperService)
        {
            _paperService = paperService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = _paperService.GetAll();
            return Ok(result);
        }
        // GET api/search
        [HttpPost("search")]
        public IActionResult Search([FromBody]Paper value)
        {
            var result = _paperService.GetAll();
            var x = result.Where(p => String.IsNullOrEmpty(value.Title) ? true : p.Title.ToLower().Contains(value.Title.ToLower()))
                .Where(p => value.DocumentType == 0 ? true : p.DocumentType == value.DocumentType)
                .Where(p => String.IsNullOrEmpty(value.Author) ? true : p.Author.ToLower().Contains(value.Author.ToLower()))
                .Where(p => String.IsNullOrEmpty(value.YearSubmitted) ? true : p.YearSubmitted.ToLower().Contains(value.YearSubmitted.ToLower()))
                .Where(p => String.IsNullOrEmpty(value.Remarks) ? true : p.Remarks.ToLower().Contains(value.Remarks.ToLower())).OrderBy(p => p.Title).ToList();
            return Ok(x);
        }
        // GET api/values
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _paperService.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Paper value)
        {
            var result = _paperService.Add(value);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(409);
            }
        }

        // PUT api/values
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]Paper value)
        {
            var result = _paperService.Update(value);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(404);
            }
        }
    }
}
