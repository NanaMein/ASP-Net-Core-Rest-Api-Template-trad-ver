using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Services
{
    public interface ITemplateService
    {
        Task<List<TemplateModel>> GetAllAsync();
        Task<TemplateModel?> GetByIdAsync(int id);
        Task<TemplateModel> CreateTemplateAsync(TemplateModel model);
        Task<TemplateModel?> UpdateTemplateAsync(int id,TemplateModel model);
        Task<bool> DeleteTemplateAsync(int id);
        Task<TemplateModel> ResetAllTemplateDatabaseAsync();
    }
}
