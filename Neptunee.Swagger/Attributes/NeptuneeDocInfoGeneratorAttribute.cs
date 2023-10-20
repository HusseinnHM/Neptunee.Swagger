namespace Neptunee.Swagger.Attributes;

public sealed class NeptuneeDocInfoGeneratorAttribute : Attribute
{
    public NeptuneeDocInfoGeneratorAttribute(string title = "", string description = "", string version = "")
    {
        Title = title;
        Version = version;
        Description = description;
    }

    public string Title { get; set; }
    public string Version { get; set; }
    public string Description { get; set; }
}