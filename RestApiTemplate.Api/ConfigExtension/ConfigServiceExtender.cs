using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Api.Data;
using RestApiTemplate.Api.Repositories;
using RestApiTemplate.Api.Services;
using RestApiTemplate.Api.ValueGenerators;
using RestApiTemplate.Api.Mappings;
//using Microsoft.Extensions.DependencyInjection;
namespace RestApiTemplate.Api.ConfigExtension
{
    public static class ConfigServiceExtender
    {
        public static void ConfigureService(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            //Configuration for SQL Server and Ef Core
            builder.Services.AddDbContext<TemplateDbContext>(opt => 
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Addscoped for service layer and repository layer
            builder.Services.AddScoped<ITemplateService, TemplateService>();
            builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();

            //Automapper
            builder.Services.AddAutoMapper(typeof(AutoMappingServices));

            //For strategy pattern
            builder.Services.AddScoped<IDateOnlyValue, DateOnlyValue>();
            builder.Services.AddScoped<IDateTimeValue, DateTimeValue>();
            builder.Services.AddScoped<INullableGuidConverter, NullableGuidConverter>();

        }
    }
}
