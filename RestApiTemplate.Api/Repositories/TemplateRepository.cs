using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Api.Data;
using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly TemplateDbContext _context;
        private readonly IMapper _mapper;

        public TemplateRepository(TemplateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TemplateModel> CreateTemplateRepository(TemplateModel model)
        {
            await _context.TemplateModels.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<TemplateModel>> GetAllRepository()
        {
            return await _context.TemplateModels.ToListAsync();
        }

        public async Task<TemplateModel?> GetByIdRepository(Guid? id)
        {
            var exisitingId = await _context.TemplateModels.FindAsync(id);
            if(exisitingId==null || id==null ) 
            { 
                return null; 
            }
            return exisitingId;
        }

        public async Task<TemplateModel?> UpdateTemplateRepository(TemplateModel model)
        {
            var exisitingTemplate = await _context.TemplateModels.FindAsync(model.GuidId);

            if (exisitingTemplate == null)
            {
                return null;
            }
            exisitingTemplate.Name = model.Name;
            exisitingTemplate.DateLastModified = model.DateLastModified;

            //var updatingTemplate = mapper.Map(model.Name, exisitingTemplate.Name);


            await _context.SaveChangesAsync();

            return exisitingTemplate;
        }

        public async Task<bool> DeleteTemplateRepository(Guid id)
        {
            var existingTemplate = await _context.TemplateModels.FindAsync(id);

            if (existingTemplate != null)
            {
                _context.TemplateModels.Remove(existingTemplate);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


        //*****************************************************************************************************
        public async Task<bool> ResetAllTemplateDatabaseRepository()
        {
            var deletedDb = await _context.Database.EnsureDeletedAsync();
            if (deletedDb == false) { return false; }

            var createdDb = await _context.Database.EnsureCreatedAsync();
            if (createdDb == false) { return false; }
            return true;


        }

        public async Task<bool> ExistingDataInRepository(Guid id)
        {
            var existingData = await _context.TemplateModels.FindAsync(id);
            if (existingData != null) { return true; }
            return false;
        }

        
    }
}
