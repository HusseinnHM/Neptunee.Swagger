using Microsoft.AspNetCore.Mvc;

namespace Neptunee.Swagger.Attributes;

public class NeptuneeApiGroupAttribute<TEnum> : NeptuneeApiGroupAttribute where TEnum : Enum
{
    public NeptuneeApiGroupAttribute()
    {
        
    }
    public NeptuneeApiGroupAttribute(params TEnum[] groupsNames)
    {
        GroupName = string.Join(",", groupsNames);
    }
}