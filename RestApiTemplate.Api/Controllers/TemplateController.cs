using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiTemplate.Api.Models;
using RestApiTemplate.Api.Services;
using System.Threading.Tasks;

namespace RestApiTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService service;

        public TemplateController(ITemplateService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll() 
        {
            return Ok(await service.GetAllAsync()); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById(int id) 
        { 
            var existingTemplate = await service.GetByIdAsync(id);

            if (existingTemplate == null) 
            {
                return NotFound();
            }
            return Ok(existingTemplate); 
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TemplateModel model) 
        { 
            var createdTemplate = await service.CreateTemplateAsync(model);

            return CreatedAtAction(nameof(ReadById), new { id = createdTemplate.Id }, createdTemplate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id ,[FromBody] TemplateModel model) 
        {
            var updatedTemplate = await service.UpdateTemplateAsync(id, model);
            return Ok(updatedTemplate); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var deletedTemplate = await service.DeleteTemplateAsync(id);
            if (deletedTemplate == false) { return NotFound(); }
            return NoContent(); 
        }

        [HttpDelete]
        public IActionResult ResetDatabase() 
        {
            return Ok(); 
        }


    }
}
