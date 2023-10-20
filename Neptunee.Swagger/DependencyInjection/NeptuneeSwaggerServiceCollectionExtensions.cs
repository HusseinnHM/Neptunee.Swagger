using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Neptunee.Swagger.DependencyInjection;

public static class NeptuneeSwaggerServiceCollectionExtensions
{
    public static IServiceCollection AddNeptuneeSwagger(this IServiceCollection services, Action<SwaggerGenOptions>? options = null)
    {
        if (options is not null)
        {
            services.Configure(options);
        }

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(o =>
        {
            o.CustomSchemaIds(s => s.FullName!.Replace("+", "."));
            o.EnableAnnotations(true, true);
            var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{AppDomain.CurrentDomain.FriendlyName}.xml");
            if (File.Exists(xmlPath))
            {
                o.IncludeXmlComments(xmlPath,true);
            }
        });

        return services;
    }

   
}