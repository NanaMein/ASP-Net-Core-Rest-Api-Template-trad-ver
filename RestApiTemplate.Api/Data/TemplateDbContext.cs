using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Api.Models;

namespace RestApiTemplate.Api.Data
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options) { }

        public DbSet<TemplateModel> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TemplateModel>(templateModel =>
            {
                templateModel.HasKey(x => x.Id);
                templateModel.Property(x => x.Name).IsRequired();
            });
        } 
    }
}
