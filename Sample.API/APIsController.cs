using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neptunee.Swagger.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.API.Controllers;

[ApiController]
[Route("api/[action]")]
public class APIsController : ControllerBase
{
   

    /// <param name="id">IDK :)</param>
    [HttpGet, NeptuneeApiGroup<SampleApiGroup>(SampleApiGroup.Module1,SampleApiGroup.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(List<Guid>))]
    public IActionResult V1(Guid id)
        => Ok();


    [HttpGet, NeptuneeApiGroup<SampleApiGroup>(SampleApiGroup.Module2,SampleApiGroup.MobileApp)]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Guid))]
    public IActionResult V2()
        => Ok();

    [Authorize(Roles = "SuperMane")]
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(bool))]
    public IActionResult Sample()
        => Ok();

    [Authorize("VIP")]
    [HttpGet, NeptuneeApiGroup<SampleApiGroup>(SampleApiGroup.Dashboard)]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(string))]
    public IActionResult Sample2()
        => Ok();
}