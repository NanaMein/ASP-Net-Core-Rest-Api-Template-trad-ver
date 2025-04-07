using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Api.Data;

namespace RestApiTemplate.Api.ConfigExtension
{
    public static class ConfigServiceExtender
    {
        public static void ConfigureService(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<TemplateDbContext>(opt => 
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        }
    }
}
