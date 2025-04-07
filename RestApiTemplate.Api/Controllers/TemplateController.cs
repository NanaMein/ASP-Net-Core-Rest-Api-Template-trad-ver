using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiTemplate.Api.DTOs;
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
        public async Task<IActionResult> Create([FromBody]TemplateModelDtoPostRequest dto) 
        { 
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            }
            try
            {
                var (Id, createdTemplate) = await service.CreateTemplateAsync(dto);

                return CreatedAtAction(nameof(ReadById), new { id = Id }, createdTemplate);
            }

            //Optional Use of Problem Details (RFC 7807):
            catch (Exception)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = 500,
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred. Please try again later."
                };
                return StatusCode(500, problemDetails);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id ,[FromBody] TemplateModelDtoPostRequest dto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                var updatedTemplate = await service.UpdateTemplateAsync(id, dto);
                if (updatedTemplate == null) 
                {
                    return NotFound(); 
                }

                return Ok(updatedTemplate);
            }

            catch 
            { 
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var deletedTemplate = await service.DeleteTemplateAsync(id);
            if (deletedTemplate == false) 
            {
                return NotFound(); 
            }

            return NoContent(); 
        }

        


    }
}
