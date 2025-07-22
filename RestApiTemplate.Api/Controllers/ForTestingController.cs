using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiTemplate.Api.Services;
using System.Threading.Tasks;

namespace RestApiTemplate.Api.Controllers
{
    [Route("api/testing")]
    [ApiController]
    public class ForTestingController : ControllerBase
    {
        private readonly ITemplateService _service;

        public ForTestingController(ITemplateService service)
        {
            _service = service;
        }

        [HttpGet("get-all-no-filter")]
        public async Task<IActionResult> Get() 
        {
            return Ok(await _service.TestingGetAllAsync());        
        }

        [HttpDelete("reset-database")]
        public async Task<IActionResult> ResetDatabase()
        {
            var resetDb = await _service.ResetAllTemplateDatabaseAsync();
            if (resetDb == false) { return BadRequest(); }
            return Ok();
        }

    }
}
