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

        public async Task<(int Id,TemplateModelDtoPostResponse)> CreateTemplateAsync(TemplateModelDtoPostRequest dto)//HTTP POST
        {
            var date = DateTime.UtcNow;

            var newTemplate = new TemplateModel 
            {
                Name = dto.Name,
                DateOnlyCreated = DateOnly.FromDateTime(date),
                DateLastModified = date,
                DateTimeCreated = date
            };

            var createdTemplate = await repository.CreateTemplateRepository(newTemplate);

            var dtoResponse = mapper.Map<TemplateModelDtoPostResponse>(createdTemplate);

            return ( createdTemplate.Id , dtoResponse );


        }

        public async Task<List<TemplateModelDtoPostResponse>> GetAllAsync()//HTTP GET
        {
            var originalList = await repository.GetAllRepository();
            var dtoList = mapper.Map<List<TemplateModelDtoPostResponse>>(originalList);
            return dtoList;
        }

        public async Task<TemplateModelDtoPostResponse?> GetByIdAsync(int id)//HTTP GET by id
        {
            var existingTemplate = await repository.GetByIdRepository(id);
            if (existingTemplate == null) 
            {
                return null;
            }

            var dtoTemplate = mapper.Map<TemplateModelDtoPostResponse>(existingTemplate);

            return dtoTemplate;

        }

        public async Task<TemplateModelDtoPostResponse?> UpdateTemplateAsync(int id, TemplateModelDtoPostRequest dto)//HTTP PUT
        {
            DateOnly dateOnly = DateOnly.FromDateTime(DateTime.UtcNow);

            var updatingTemplate = new TemplateModel
            {
                Id = id,
                Name= dto.Name,
                DateLastModified=DateTime.UtcNow,
                DateOnlyCreated=dateOnly
            };

            var updatedTemplate = await repository.UpdateTemplateRepository(updatingTemplate);

            return mapper.Map<TemplateModelDtoPostResponse?>(updatedTemplate);

        }

        public async Task<bool> DeleteTemplateAsync(int id)//HTTP DELETE
        {
            return await repository.DeleteTemplateRepository(id);
        }




        //for testing purposes 

        //*********************************************************************************************************
        public async Task<List<TemplateModel>> TestingGetAllAsync()
        {
            return await repository.GetAllRepository();
        }

        public async Task<bool> ResetAllTemplateDatabaseAsync()
        {
            return await repository.ResetAllTemplateDatabaseRepository();
        }


    }
}
