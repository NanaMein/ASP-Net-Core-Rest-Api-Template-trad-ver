using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiTemplate.Api.Services;
using System.Threading.Tasks;

namespace RestApiTemplate.Api.Controllers
{
    [Route("api/development/testing")]
    [ApiController]
    public class ForTestingController : ControllerBase
    {
        private readonly ITemplateService service;

        public ForTestingController(ITemplateService service)
        {
            this.service = service;
        }

        [HttpGet("get-all-no-filter")]
        public async Task<IActionResult> Get() 
        {
            return Ok(await service.TestingGetAllAsync());        
        }

        [HttpDelete("reset-database")]
        public async Task<IActionResult> ResetDatabase()
        {
            var resetDb = await service.ResetAllTemplateDatabaseAsync();
            if (resetDb == false) { return BadRequest(); }
            return Ok();
        }
    }
}
