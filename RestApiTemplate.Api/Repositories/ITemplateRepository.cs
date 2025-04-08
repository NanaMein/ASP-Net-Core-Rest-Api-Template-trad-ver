using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Repositories
{
    public interface ITemplateRepository
    {

        Task<TemplateModel> CreateTemplateRepository(TemplateModel model);

        Task<List<TemplateModel>> GetAllRepository();

        Task<TemplateModel?> GetByIdRepository(Guid? id);

        Task<TemplateModel?> UpdateTemplateRepository(TemplateModel model);

        Task<bool> DeleteTemplateRepository(Guid id);

        //*********************************************************

        Task<bool> ResetAllTemplateDatabaseRepository();
        Task<bool> ExistingDataInRepository(Guid id);
    }
}
