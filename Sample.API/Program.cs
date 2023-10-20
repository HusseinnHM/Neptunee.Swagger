using Microsoft.OpenApi.Models;
using Neptunee.Swagger;
using Neptunee.Swagger.DependencyInjection;
using Sample.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddNeptuneeSwagger(o =>
    o.SwaggerDocs<SampleApiGroup>()
        .GroupNamesDocInclusion(escapeDocs: SampleApiGroup.All.ToString())
        .AddJwtBearerSecurityScheme());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseNeptuneeSwagger(o => o.AddEndpoints<SampleApiGroup>());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();