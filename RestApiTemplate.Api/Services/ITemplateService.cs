using RestApiTemplate.Api.DTOs;
using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Services
{
    public interface ITemplateService
    {        
        Task<(Guid Id,TemplateModelDtoPostResponse)> CreateTemplateAsync(TemplateModelDtoPostRequest dto);

        Task<List<TemplateModelDtoPostResponse>> GetAllAsync();

        Task<TemplateModelDtoPostResponse?> GetByIdAsync(Guid id);

        Task<TemplateModelDtoPostResponse?> UpdateTemplateAsync(Guid id,TemplateModelDtoPostRequest dto);

        Task<bool> DeleteTemplateAsync(Guid id);


        //testing purposes, can also look up all info saved in database without dto
        //****************************************************************************************************

        Task<bool> ResetAllTemplateDatabaseAsync();
        Task<List<TemplateModel>> TestingGetAllAsync();
        Task<bool> ExisitingDataAsync(Guid id);


    }
}
