using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {

            var result = "updated";
            return Ok(result);
        }

    }
}
