using Common.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IExcelReader _excelReader;
        public EmployeeController(IExcelReader excelReader)
        {
            _excelReader = excelReader;
        }

        [HttpPost("excel")]
        public async Task<IActionResult> PostExcelFile(IFormFile file)
        {

            if (file == null || file.Length == 0)
                return BadRequest();

            string fileExtension = System.IO.Path.GetExtension(file.FileName);
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
                return BadRequest();

            using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            memoryStream.Position = 0;

            return Ok(_excelReader.DecerializeInMemoryExcelToClass(memoryStream, true));
        }

    }

}
