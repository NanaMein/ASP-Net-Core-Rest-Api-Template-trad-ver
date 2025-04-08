using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Api.Data;
using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly TemplateDbContext context;
        private readonly IMapper mapper;

        public TemplateRepository(TemplateDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TemplateModel> CreateTemplateRepository(TemplateModel model)
        {
            await context.TemplateModels.AddAsync(model);
            await context.SaveChangesAsync();
            return model;
        }

        public async Task<List<TemplateModel>> GetAllRepository()
        {
            return await context.TemplateModels.ToListAsync();
        }

        public async Task<TemplateModel?> GetByIdRepository(Guid? id)
        {
            var exisitingId = await context.TemplateModels.FindAsync(id);
            if(exisitingId==null || id==null ) 
            { 
                return null; 
            }
            return exisitingId;
        }

        public async Task<TemplateModel?> UpdateTemplateRepository(TemplateModel model)
        {
            var exisitingTemplate = await context.TemplateModels.FindAsync(model.GuidId);

            if (exisitingTemplate == null)
            {
                return null;
            }
            exisitingTemplate.Name = model.Name;
            exisitingTemplate.DateLastModified = model.DateLastModified;

            //var updatingTemplate = mapper.Map(model.Name, exisitingTemplate.Name);


            await context.SaveChangesAsync();

            return exisitingTemplate;
        }

        public async Task<bool> DeleteTemplateRepository(Guid id)
        {
            var existingTemplate = await context.TemplateModels.FindAsync(id);

            if (existingTemplate != null)
            {
                context.TemplateModels.Remove(existingTemplate);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }


        //*****************************************************************************************************
        public async Task<bool> ResetAllTemplateDatabaseRepository()
        {
            var deletedDb = await context.Database.EnsureDeletedAsync();
            if (deletedDb == false) { return false; }

            var createdDb = await context.Database.EnsureCreatedAsync();
            if (createdDb == false) { return false; }
            return true;


        }

        public async Task<bool> ExistingDataInRepository(Guid id)
        {
            var existingData = await context.TemplateModels.FindAsync(id);
            if (existingData != null) { return true; }
            return false;
        }

        
    }
}
