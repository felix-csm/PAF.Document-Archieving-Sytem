using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PAF.DAS.Service.Interfaces;
using PAF.DAS.Service.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PAF.DAS.WebAPI.Controllers
{
    [Authorize]
    [Route("api/paperarchives")]
    public class PaperArchievesController : Controller
    {
        private readonly IPaperArchieveService _paperArchieveService;
        private readonly IPaperService _paperService;
        private readonly IPaperStatisticsService _paperStatisticsService;
        private string _tempPath = "";

        public PaperArchievesController(IPaperArchieveService paperArchieveService, IPaperStatisticsService paperStatisticsService, IPaperService paperService)
        {
            _paperArchieveService = paperArchieveService;
            _paperService = paperService;
            _paperStatisticsService = paperStatisticsService;
            _tempPath = Path.GetTempPath();
        }
        [HttpGet, Route("stats")]
        public IActionResult GetStats()
        {
            var result = new List<PaperStatistic>();
            if (_paperStatisticsService.GetAll().Count < 4)
            {
                result = _paperStatisticsService.GetAll().OrderByDescending(o => o.Downloaded).ToList();
            }
            else
            {
                result = _paperStatisticsService.GetAll().OrderByDescending(o => o.Downloaded).Take(2).ToList();
            }
            var list = result.Join(
                    _paperService.GetAll(),
                    stat => stat.PaperId,
                    paper => paper.Id,
                    (stat, paper) => new { Paper = paper, PaperStatistic = stat });
            return Ok(list);
        }

        [HttpPost, Route("upload")]
        public async Task<IActionResult> Upload()
        {
            var input = HttpContext.Request.Form.Files[0];
            var extension = input.FileName.Substring(input.FileName.LastIndexOf('.'));
            var fileName = Guid.NewGuid().ToString() + extension;
            var filePath = Path.Combine(_tempPath, fileName);

            // Save the uploaded file to "UploadedFiles" folder
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await input.CopyToAsync(fileStream);
            };

            return Ok(new { fileName });
        }

        [HttpGet("{id}/file")]
        public IActionResult GetFile(Guid id)
        {
            var paper = _paperService.Get(id);
            var result = _paperArchieveService.GetByPaperId(id);
            if (result != null)
            {
                FileInfo file = new FileInfo(result.Location);
                _paperStatisticsService.AddDownloaded(id);
                return File(ReadFile(result.Location), "application/pdf");
            }
            else
            {
                return StatusCode(404);
            }
        }

        private byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
    }
}
