using RestApiTemplate.Api.ConfigExtension;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureService();

var app = builder.Build();

app.ConfigureApplication();





app.Run();
