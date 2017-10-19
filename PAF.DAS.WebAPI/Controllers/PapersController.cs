﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PAF.DAS.Service.Interfaces;
using PAF.DAS.Service.Model;

namespace PAF.DAS.WebAPI.Controllers
{
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
        public IEnumerable<Paper> Get()
        {
            return _paperService.GetAll();
        }

        // GET api/values/5
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
