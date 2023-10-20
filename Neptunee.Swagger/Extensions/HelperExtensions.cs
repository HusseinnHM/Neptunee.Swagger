using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Neptunee.Swagger;

internal static class HelperExtensions
{
    internal static IEnumerable<string> GroupNames(this ApiDescription apiDescription)
        => apiDescription.GroupName?.Split(",") ?? Array.Empty<string>();
}