using Scalar.AspNetCore;

namespace RestApiTemplate.Api.ConfigExtension
{
    public static class ConfigApplicationExtender
    {
        public static void ConfigureApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                //Scalar for testing and debug API
                app.MapScalarApiReference();
                app.MapOpenApi();
            }
            //Middleware 
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }
    }
}
