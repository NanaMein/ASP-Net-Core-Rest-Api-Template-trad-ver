using RestApiTemplate.Api.DTOs;
using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Services
{
    public interface ITemplateService
    {
        Task<List<TemplateModelDtoPostResponse>> GetAllAsync();

        Task<TemplateModel?> GetByIdAsync(int id);

        Task<TemplateModel> CreateTemplateAsync(TemplateModel model);

        Task<TemplateModel?> UpdateTemplateAsync(int id,TemplateModel model);

        Task<bool> DeleteTemplateAsync(int id);


        //testing purposes, can also look up all info saved in database without dto
        Task<bool> ResetAllTemplateDatabaseAsync();
        Task<List<TemplateModel>> TestingGetAllAsync();

    }
}
