using Neptunee.Swagger.Attributes;

namespace Sample.API;

public enum SampleApiGroup
{
    [NeptuneeDocInfoGenerator(title: "All APIs")]
    All,

    [NeptuneeDocInfoGenerator(title: "Module1 APIs", version: "v1")]
    Module1,

    [NeptuneeDocInfoGenerator(version: "Module2 APIs")]
    Module2,

    [NeptuneeDocInfoGenerator(title: "Dashboard APIs")]
    Dashboard,

    [NeptuneeDocInfoGenerator(title: "MobileApp APIs")]
    MobileApp,
}