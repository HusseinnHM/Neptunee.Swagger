using Microsoft.AspNetCore.Mvc;

namespace Neptunee.Swagger.Attributes;

public class NeptuneeApiGroupAttribute : ApiExplorerSettingsAttribute
{
    public NeptuneeApiGroupAttribute()
    {
        
    }
    public NeptuneeApiGroupAttribute(params string[] groupsNames)
    {
        GroupName = string.Join(",", groupsNames);
    }
}