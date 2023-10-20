using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Neptunee.Swagger.Attributes;
using Neptunee.Swagger.Filters;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Neptunee.Swagger;

public static class SwaggerGenOptionsExtensions
{
    public static SwaggerGenOptions AddJwtBearerSecurityScheme(this SwaggerGenOptions options)
    {
        options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
        var securitySchema = new OpenApiSecurityScheme()
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        };

        options.AddSecurityDefinition("Bearer", securitySchema);

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            { securitySchema, new[] { "Bearer" } }
        });


        return options;
    }

    public static SwaggerGenOptions GroupNamesDocInclusion(this SwaggerGenOptions options, params string[] escapeDocs)
    {
        options.OperationFilter<AppendGroupNamesToSummaryOperationFilter>();
        options.DocInclusionPredicate((docName, apiDescription)
            => escapeDocs.Any(d => d.Equals(docName, StringComparison.OrdinalIgnoreCase))
               || apiDescription.GroupNames().Any(g => docName.Equals(g, StringComparison.OrdinalIgnoreCase)));
        return options;
    }

    public static SwaggerGenOptions SwaggerDocs<TApiGroupNamesEnum>(this SwaggerGenOptions options) where TApiGroupNamesEnum : Enum
    {
        foreach (var fieldInfo in typeof(TApiGroupNamesEnum).GetFields(BindingFlags.Static | BindingFlags.Public))
        {
            if (fieldInfo.GetCustomAttribute(typeof(NeptuneeDocInfoGeneratorAttribute), false) is not NeptuneeDocInfoGeneratorAttribute openApiInfoGenerator)
            {
                throw new Exception($"{nameof(NeptuneeDocInfoGeneratorAttribute)} not found for {fieldInfo.Name}");
            }

            options.SwaggerDoc(fieldInfo.Name, new OpenApiInfo
            {
                Title = openApiInfoGenerator.Title,
                Description = openApiInfoGenerator.Description,
                Version = openApiInfoGenerator.Version,
            });
        }

        return options;
    }
}