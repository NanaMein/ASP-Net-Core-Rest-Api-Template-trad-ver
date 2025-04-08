using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Data
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options) { }

        public DbSet<TemplateModel> TemplateModels => Set<TemplateModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TemplateModel>(templateModel =>
            {
                templateModel.HasKey(x => x.GuidId);

                templateModel.Property(x => x.Name).IsRequired()
                    .HasMaxLength(50);
            });
        } 
    }
}
