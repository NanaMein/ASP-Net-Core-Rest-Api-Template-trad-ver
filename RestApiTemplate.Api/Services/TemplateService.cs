using AutoMapper;
using RestApiTemplate.Api.DTOs;
using RestApiTemplate.Api.Models;
using RestApiTemplate.Api.Repositories;

namespace RestApiTemplate.Api.Services
{
    public class TemplateService:ITemplateService
    {
        private readonly ITemplateRepository repository;
        private readonly IMapper mapper;

        public TemplateService(ITemplateRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<TemplateModel> CreateTemplateAsync(TemplateModel model)//CHECK CHECK
        {
            return await repository.CreateTemplateRepository(model);
        }

        public async Task<bool> DeleteTemplateAsync(int id)
        {
            return await repository.DeleteTemplateRepository(id);
        }

        public async Task<List<TemplateModelDtoPostResponse>> GetAllAsync()//CHECK CHECK
        {
            var originalList =  await repository.GetAllRepository();
            var dtoList = mapper.Map<List<TemplateModelDtoPostResponse>>(originalList);
            return dtoList;
        }

        public async Task<TemplateModel?> GetByIdAsync(int id)//CHECK CHECK
        {
            return await repository.GetByIdRepository(id);
        }

        public async Task<bool> ResetAllTemplateDatabaseAsync()
        {
            return await repository.ResetAllTemplateDatabaseRepository();
        }

        public async Task<List<TemplateModel>> TestingGetAllAsync()
        {
            return await repository.GetAllRepository();
        }

        public async Task<TemplateModel?> UpdateTemplateAsync(int id, TemplateModel model)//CHECK CHECK
        {
            return await repository.UpdateTemplateRepository(id, model);
        }
    }
}
