using RestApiTemplate.Api.DTOs;
using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Services
{
    public interface ITemplateService
    {        
        Task<(int Id,TemplateModelDtoPostResponse)> CreateTemplateAsync(TemplateModelDtoPostRequest dto);

        Task<List<TemplateModelDtoPostResponse>> GetAllAsync();

        Task<TemplateModelDtoPostResponse?> GetByIdAsync(int id);

        Task<TemplateModelDtoPostResponse?> UpdateTemplateAsync(int id,TemplateModelDtoPostRequest dto);

        Task<bool> DeleteTemplateAsync(int id);


        //testing purposes, can also look up all info saved in database without dto
        //****************************************************************************************************

        Task<bool> ResetAllTemplateDatabaseAsync();
        Task<List<TemplateModel>> TestingGetAllAsync();
        Task<bool> ExisitingDataAsync(int id);


    }
}
