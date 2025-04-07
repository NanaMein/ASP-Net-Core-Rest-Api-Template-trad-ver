using RestApiTemplate.Api.Models;
using RestApiTemplate.Api.Repositories;

namespace RestApiTemplate.Api.Services
{
    public class TemplateService:ITemplateService
    {
        private readonly ITemplateRepository repository;

        public TemplateService(ITemplateRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TemplateModel> CreateTemplateAsync(TemplateModel model)//CHECK CHECK
        {
            return await repository.CreateTemplateRepository(model);
        }

        public async Task<bool> DeleteTemplateAsync(int id)
        {
            return await repository.DeleteTemplateRepository(id);
        }

        public async Task<List<TemplateModel>> GetAllAsync()//CHECK CHECK
        {
            return await repository.GetAllRepository();
        }

        public async Task<TemplateModel?> GetByIdAsync(int id)//CHECK CHECK
        {
            return await repository.GetByIdRepository(id);
        }

        public Task<TemplateModel> ResetAllTemplateDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TemplateModel?> UpdateTemplateAsync(int id, TemplateModel model)//CHECK CHECK
        {
            return await repository.UpdateTemplateRepository(id, model);
        }
    }
}
