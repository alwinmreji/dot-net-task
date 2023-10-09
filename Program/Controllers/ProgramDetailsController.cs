using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Program.Core;
using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramDetailsController : ControllerBase
    {
        private readonly ProgramDetailsCore _programDetails;
        
        public ProgramDetailsController(ProgramDetailsCore programDetails)
        {
            _programDetails= programDetails;
        }

        [HttpGet]
        [Route("getProgramDetails")]
        public async Task<IActionResult> GetProgramDetailsAsync()
        {
            try
            {
                var result = await _programDetails.GetProgramDetailsAsync();
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("insertProgramDetails")]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertProgramDetailsAsync(ProgramDetailsDto programDetails)
        {
            try
            {
                var result = await _programDetails.InsertProgramDetailsAsync(programDetails);
                
                if(result == true) return Ok();
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
    }
}
