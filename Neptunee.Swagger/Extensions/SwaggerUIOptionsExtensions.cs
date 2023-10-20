using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Neptunee.Swagger;

public static class SwaggerUIOptionsExtensions
{
    public static SwaggerUIOptions SetDocExpansion(this SwaggerUIOptions options, DocExpansion docExpansion = DocExpansion.None)
    {
        options.DocExpansion(docExpansion);
        return options;
    }

    public static SwaggerUIOptions AddEndpoint(this SwaggerUIOptions options, string docName, string? name = null)
    {
        options.SwaggerEndpoint($"/swagger/{docName}/swagger.json", name ?? docName);
        return options;
    }

    public static SwaggerUIOptions AddEndpoints<TApiGroupNamesEnum>(this SwaggerUIOptions options) where TApiGroupNamesEnum : Enum
    {
        foreach (var f in typeof(TApiGroupNamesEnum).GetFields(BindingFlags.Static | BindingFlags.Public))
        {
            options.AddEndpoint(f.Name, f.Name);
        }

        return options;
    }
}