﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PAF.DAS.Service.Interfaces;
using PAF.DAS.Service.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PAF.DAS.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/papers")]
    public class PapersController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly IPaperService _paperService;
        private readonly IPaperArchieveService _paperArchiveService;
        private readonly IMapper _mapper;

        public PapersController(IPaperService paperService, IMapper mapper, IPaperArchieveService paperArchiveService, IHostingEnvironment environment)
        {
            _paperService = paperService;
            _paperArchiveService = paperArchiveService;
            _mapper = mapper;
            _hostingEnvironment = environment;
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
        public IActionResult Search([FromBody]PaperArchiveModel value)
        {
            var result = _paperService.GetAll();
            var list = result.Where(p => String.IsNullOrEmpty(value.Title) ? true : p.Title.ToLower().Contains(value.Title.ToLower()))
                .Where(p => value.DocumentType == 0 ? true : p.DocumentType == value.DocumentType)
                .Where(p => String.IsNullOrEmpty(value.Author) ? true : p.Author.ToLower().Contains(value.Author.ToLower()))
                .Where(p => String.IsNullOrEmpty(value.YearSubmitted) ? true : p.YearSubmitted.ToLower().Contains(value.YearSubmitted.ToLower()))
                .Where(p => String.IsNullOrEmpty(value.Remarks) ? true : p.Remarks.ToLower().Contains(value.Remarks.ToLower())).OrderBy(p => p.Title).ToList();

            var paper = _mapper.Map<List<Paper>, List<PaperArchiveModel>> (list);
            return Ok(list);
        }
        // GET api/values
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _paperService.Get(id);
            if (result != null)
            {
                var paper = _mapper.Map<Paper, PaperArchiveModel>(result);
                return Ok(paper);
            }
            else
            {
                return StatusCode(404);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]PaperArchiveModel value)
        { 
            var paper = _mapper.Map<PaperArchiveModel, Paper>(value);
            var result = _paperService.Add(paper);
            if (result != null)
            {
                string tempPath = Path.Combine(Path.GetTempPath(), value.FileName.ToString());
                string uploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                string officialPath = Path.Combine(uploadPath, value.FileName.ToString());
                _paperArchiveService.Add(new PaperArchieve
                {
                    FileName = value.FileName.ToString(),
                    Location = officialPath,
                    PaperId = result.Id
                });

                FileInfo file = new FileInfo(tempPath);
                DirectoryInfo uploadDirectory = new DirectoryInfo(uploadPath);
                if(file.Exists)
                {
                    if (!uploadDirectory.Exists)
                    {
                        uploadDirectory.Create();
                    }
                    file.CopyTo(officialPath);
                    file.Delete();
                }

                return Ok(result);
            }
            else
            {
                return StatusCode(409);
            }
        }

        // PUT api/values
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]PaperArchiveModel value)
        {
            var paper = _mapper.Map<PaperArchiveModel, Paper>(value);
            var result = _paperService.Update(paper);
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
