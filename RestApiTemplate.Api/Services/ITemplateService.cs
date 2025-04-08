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
        Task<bool> ExisitingDataAsync(Guid id);

        //because of dto, its hard to show GuidId, thats why we use this service
        Task<List<TemplateModel>> TestingGetAllAsync();


    }
}
