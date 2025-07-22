using AutoMapper;
using RestApiTemplate.Api.DTOs;
using RestApiTemplate.Api.Models;
using RestApiTemplate.Api.Repositories;
using RestApiTemplate.Api.ValueGenerators;

namespace RestApiTemplate.Api.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository repository;
        private readonly IMapper mapper;
        private readonly IDateOnlyValue dateOnly;
        private readonly IDateTimeValue dateTime;

        public TemplateService(ITemplateRepository repository, IMapper mapper, IDateOnlyValue dateOnly, IDateTimeValue dateTime)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.dateOnly = dateOnly;
            this.dateTime = dateTime;
        }

        public async Task<(Guid Id, TemplateModelDtoPostResponse)> CreateTemplateAsync(TemplateModelDtoPostRequest dto)//HTTP POST
        {
            var newTemplate = new TemplateModel
            {
                Name = dto.Name,
                DateOnlyCreated = dateOnly.GenerateValue(),
                DateTimeCreated = dateTime.GenerateValue(),
                DateLastModified = dateTime.GenerateValue()
            };

            var createdTemplate = await repository.CreateTemplateRepository(newTemplate);

            var dtoResponse = mapper.Map<TemplateModelDtoPostResponse>(createdTemplate);

            return (createdTemplate.GuidId, dtoResponse);


        }

        public async Task<List<TemplateModelDtoPostResponse>> GetAllAsync()//HTTP GET
        {
            var originalList = await repository.GetAllRepository();
            var dtoList = mapper.Map<List<TemplateModelDtoPostResponse>>(originalList);
            return dtoList;
        }

        public async Task<TemplateModelDtoPostResponse?> GetByIdAsync(Guid id)//HTTP GET by id
        {

            var existingId = await repository.GetByIdRepository(id);
            if (existingId == null) 
            {
                return null;
            }

            return mapper.Map<TemplateModelDtoPostResponse>(existingId);
        }

        public async Task<TemplateModelDtoPostResponse?> UpdateTemplateAsync(Guid id, TemplateModelDtoPostRequest dto)//HTTP PUT
        {


            var updatingTemplate = new TemplateModel
            {
                GuidId = id,
                Name = dto.Name,
                DateLastModified = dateTime.GenerateValue(),
            };

            var updatedTemplate = await repository.UpdateTemplateRepository(updatingTemplate);

            return mapper.Map<TemplateModelDtoPostResponse?>(updatedTemplate);

        }

        public async Task<bool> DeleteTemplateAsync(Guid id)//HTTP DELETE
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

        public async Task<bool> ExisitingDataAsync(Guid id)
        {
            return await repository.ExistingDataInRepository(id);
        }

    }
}
