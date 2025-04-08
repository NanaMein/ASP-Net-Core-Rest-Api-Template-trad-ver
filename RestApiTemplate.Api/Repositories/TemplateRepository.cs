using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Api.Data;
using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Repositories
{
    public class TemplateRepository:ITemplateRepository
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
            await context.Templates.AddAsync(model);
            await context.SaveChangesAsync();
            return model;
        }

        public async Task<List<TemplateModel>> GetAllRepository()
        {
            return await context.Templates.ToListAsync();
        }

        public async Task<TemplateModel?> GetByIdRepository(int id)
        {
            var exisitingTemplate = await context.Templates.FindAsync(id);
            if (exisitingTemplate == null) {return null;}
            return exisitingTemplate;

        }

        public async Task<TemplateModel?> UpdateTemplateRepository(TemplateModel model)
        {
            var exisitingTemplate = await context.Templates.FindAsync(model.Id);

            if (exisitingTemplate == null) 
            {
                return null;
            }

            var updatingTemplate = mapper.Map(model , exisitingTemplate);
            

            await context.SaveChangesAsync();

            return updatingTemplate;
           


            //if (exisitingTemplate != null)
            //{
            //    var updatedTemplate = mapper.Map(model, exisitingTemplate);

            //    //explicit because of some experience. but usually or common approach is implicit
            //    updatedTemplate.Id = exisitingTemplate.Id;
            //    await context.SaveChangesAsync();

            //    return updatedTemplate;
            //}
            //return null;
        }

        public async Task<bool> DeleteTemplateRepository(int id)
        {
            var existingTemplate = await context.Templates.FindAsync(id);
            if (existingTemplate != null) 
            { 
                context.Templates.Remove(existingTemplate);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        

        //*****************************************************************************************************
        public async Task<bool> ResetAllTemplateDatabaseRepository()
        {
            var deletedDb = await context.Database.EnsureDeletedAsync();
            if (deletedDb==false) { return false; }

            var createdDb = await context.Database.EnsureCreatedAsync();
            if (createdDb==false) { return false; }
            return true;


        }

        public async Task<bool> ExistingDataInRepository(int id)
        {
            var existingData = await context.Templates.FindAsync(id);
            if (existingData != null) { return true; }
            return false;
        }




    }
}
