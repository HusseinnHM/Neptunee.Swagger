using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Neptunee.Swagger;

public static class NeptuneeSwaggerAppBuilderExtensions
{
    public static IApplicationBuilder UseNeptuneeSwagger(this IApplicationBuilder app, Action<SwaggerUIOptions>? setupAction = null)
        => app.UseSwagger()
            .UseSwaggerUI(setupAction);
}