using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PAF.DAS.Service.Interfaces;
using PAF.DAS.Service.Model;

namespace PAF.DAS.WebAPI.Controllers
{
    [Route("api/paperarchieves")]
    public class PaperArchievesController : Controller
    {
        private readonly IPaperArchieveService _paperArchieveService;

        public PaperArchievesController(IPaperArchieveService paperArchieveService)
        {
            _paperArchieveService = paperArchieveService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _paperArchieveService.Get(id);
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
        public void Post([FromBody]string value)
        {
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
