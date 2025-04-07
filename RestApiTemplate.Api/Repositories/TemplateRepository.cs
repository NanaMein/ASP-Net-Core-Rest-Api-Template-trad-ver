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

        public async Task<TemplateModel> CreateTemplateRepository(TemplateModel model)//CHECK CHECK
        {
            await context.Templates.AddAsync(model);
            await context.SaveChangesAsync();
            return model;
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
        
        public async Task<List<TemplateModel>> GetAllRepository()//CHECK CHECK
        {
            return await context.Templates.ToListAsync();
        }

        public async Task<TemplateModel?> GetByIdRepository(int id)//CHECK CHECK
        {
            return await context.Templates.FindAsync(id);

        }

        public Task<TemplateModel> ResetAllTemplateDatabaseRepository()
        {
            throw new NotImplementedException();
        }

        public async Task<TemplateModel?> UpdateTemplateRepository(int id, TemplateModel model)//CHECK CHECK
        {
            var exisitingTemplate = await context.Templates.FindAsync(id);

            if (exisitingTemplate != null) 
            {
                var updatedTemplate = mapper.Map(model, exisitingTemplate);

                //explicit because of some experience. but usually or common approach is implicit
                updatedTemplate.Id = exisitingTemplate.Id;
                await context.SaveChangesAsync();

                return updatedTemplate;
            }
            return null;
        }



    }
}
