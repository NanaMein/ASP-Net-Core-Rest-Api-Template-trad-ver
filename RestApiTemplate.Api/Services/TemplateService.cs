using AutoMapper;
using RestApiTemplate.Api.DTOs;
using RestApiTemplate.Api.Models;
using RestApiTemplate.Api.Repositories;
using RestApiTemplate.Api.ValueGenerators;

namespace RestApiTemplate.Api.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDateOnlyValue _dateOnly;
        private readonly IDateTimeValue _dateTime;

        public TemplateService(ITemplateRepository repository, IMapper mapper, IDateOnlyValue dateOnly, IDateTimeValue dateTime)
        {
            _repository = repository;
            _mapper = mapper;
            _dateOnly = dateOnly;
            _dateTime = dateTime;
        }

        public async Task<(Guid Id, TemplateModelDtoPostResponse)> CreateTemplateAsync(TemplateModelDtoPostRequest dto)//HTTP POST
        {
            var newTemplate = new TemplateModel
            {
                Name = dto.Name,
                DateOnlyCreated = _dateOnly.GenerateValue(),
                DateTimeCreated = _dateTime.GenerateValue(),
                DateLastModified = _dateTime.GenerateValue()
            };

            var createdTemplate = await _repository.CreateTemplateRepository(newTemplate);

            var dtoResponse = _mapper.Map<TemplateModelDtoPostResponse>(createdTemplate);

            return (createdTemplate.GuidId, dtoResponse);


        }

        public async Task<List<TemplateModelDtoPostResponse>> GetAllAsync()//HTTP GET
        {
            var originalList = await _repository.GetAllRepository();
            var dtoList = _mapper.Map<List<TemplateModelDtoPostResponse>>(originalList);
            return dtoList;
        }

        public async Task<TemplateModelDtoPostResponse?> GetByIdAsync(Guid id)//HTTP GET by id
        {

            var existingId = await _repository.GetByIdRepository(id);
            if (existingId == null) 
            {
                return null;
            }

            return _mapper.Map<TemplateModelDtoPostResponse>(existingId);
        }

        public async Task<TemplateModelDtoPostResponse?> UpdateTemplateAsync(Guid id, TemplateModelDtoPostRequest dto)//HTTP PUT
        {


            var updatingTemplate = new TemplateModel
            {
                GuidId = id,
                Name = dto.Name,
                DateLastModified = _dateTime.GenerateValue(),
            };

            var updatedTemplate = await _repository.UpdateTemplateRepository(updatingTemplate);

            return _mapper.Map<TemplateModelDtoPostResponse?>(updatedTemplate);

        }

        public async Task<bool> DeleteTemplateAsync(Guid id)//HTTP DELETE
        {
            return await _repository.DeleteTemplateRepository(id);
        }




        //for testing purposes 
        //*********************************************************************************************************



        public async Task<List<TemplateModel>> TestingGetAllAsync()
        {
            return await _repository.GetAllRepository();
        }

        public async Task<bool> ResetAllTemplateDatabaseAsync()
        {
            return await _repository.ResetAllTemplateDatabaseRepository();
        }

        public async Task<bool> ExisitingDataAsync(Guid id)
        {
            return await _repository.ExistingDataInRepository(id);
        }

    }
}
