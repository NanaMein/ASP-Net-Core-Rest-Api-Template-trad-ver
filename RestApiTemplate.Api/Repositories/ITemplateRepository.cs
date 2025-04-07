using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Repositories
{
    public interface ITemplateRepository
    {
        Task<List<TemplateModel>> GetAllRepository();
        Task<TemplateModel?> GetByIdRepository(int id);
        Task<TemplateModel> CreateTemplateRepository(TemplateModel model);
        Task<TemplateModel?> UpdateTemplateRepository(int id, TemplateModel model);
        Task<bool> DeleteTemplateRepository(int id);
        Task<TemplateModel> ResetAllTemplateDatabaseRepository();
    }
}
