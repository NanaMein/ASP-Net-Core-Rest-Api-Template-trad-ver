using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiTemplate.Api.Data;
using RestApiTemplate.Api.DTOs;
using RestApiTemplate.Api.Models;
using RestApiTemplate.Api.Services;
using RestApiTemplate.Api.ValueGenerators;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace RestApiTemplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _service;
        private readonly TemplateDbContext _context;
        private readonly INullableGuidConverter _converter;

        public TemplateController(ITemplateService service, TemplateDbContext context, INullableGuidConverter converter)
        {
            _service = service;
            _context = context;
            _converter = converter;
        }

        [HttpGet("v1")]
        public async Task<IActionResult> ReadAll() 
        {
            return Ok(await _service.GetAllAsync()); 
        }

        [HttpGet]
        [Route("v1/{id:guid}")]
        public async Task<IActionResult> ReadById(Guid id) 
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingId = await _service.GetByIdAsync(id);
                if (existingId != null)
                {
                    return Ok(existingId); 
                }

                return NotFound();
            }

            catch (Exception) 
            {
                return StatusCode(500 , $" Unexpected error occured :"); 
            }
        }

        [HttpPost("v1")]
        public async Task<IActionResult> Create([FromBody]TemplateModelDtoPostRequest dto) 
        {
            
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            }

            try
            {
                var (guid, createdTemplate) = await _service.CreateTemplateAsync(dto);

                return CreatedAtAction(nameof(ReadById), new { id = guid }, createdTemplate);
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

        [HttpPut]
        [Route("v1/{id:guid}")]
        public async Task<IActionResult> Update(Guid id ,[FromBody] TemplateModelDtoPostRequest dto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            try
            {
                var updatedTemplate = await _service.UpdateTemplateAsync(id, dto);

                if (updatedTemplate == null) 
                {
                    return NotFound(); 
                }

                return Ok(updatedTemplate);
            }

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

        [HttpDelete]
        [Route("v1/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deletedTemplate = await _service.DeleteTemplateAsync(id);
                if (deletedTemplate == false)
                {
                    return NotFound();
                }

                return NoContent();
            }

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

        


    }
}
