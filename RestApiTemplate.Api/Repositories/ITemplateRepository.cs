using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Repositories
{
    public interface ITemplateRepository
    {
        Task<List<TemplateModel>> GetAllRepository();
        Task<TemplateModel?> GetByIdRepository(int id);
        Task<TemplateModel> CreateTemplateRepository(TemplateModel model);
        Task<TemplateModel?> UpdateTemplateRepository(TemplateModel model);
        Task<bool> DeleteTemplateRepository(int id);
        Task<bool> ResetAllTemplateDatabaseRepository();
        Task<bool> ExistingDataInRepository(int id);
    }
}
