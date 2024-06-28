using System.Net.Mime;
using cleanwave_platform.Profiles.Domain.Model.Entities;
using cleanwave_platform.Profiles.Domain.Services;
using cleanwave_platform.Profiles.Interfaces.REST.Resources;
using cleanwave_platform.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace cleanwave_platform.Profiles.Interfaces.REST;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CleaningEntrepreneurController(ICleaningEntrepreneurCommandService entrepreneurCommandService,
    ICleaningEntrepreneurQueryService entrepreneurQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEntrepreneur([FromBody] CreateCleaningEntrepreneurResource createCleaningEntrepreneurResource)
    {
        var createEntrepreneurCommand =
            CreateCleaningEntrepreneurCommandFromResourceAssembler.ToCommandFromResource(createCleaningEntrepreneurResource);
        var entrepreneur = await entrepreneurCommandService.Handle(createEntrepreneurCommand);
        if (entrepreneur is null) return BadRequest();
        var resource = CleaningEntrepreneurResourceFromEntityAssembler.ToResourceFromEntity(entrepreneur);
        return CreatedAtAction(nameof(GetEntrepreneurById), new { id = resource.Id }, resource);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEntrepreneurById([FromRoute] int id)
    {
        var getEntrepreneurByIdQuery = new GetCleaningEntrepreneurByIdQuery(id);
        var entrepreneur = await entrepreneurQueryService.Handle(getEntrepreneurByIdQuery);
        if (entrepreneur is null) return BadRequest();
        var resource = CleaningEntrepreneurResourceFromEntityAssembler.ToResourceFromEntity(entrepreneur);
        return Ok(resource);
    }
    [HttpGet("{email}")]
    public async Task<IActionResult> GetEntrepreneurByEmail([FromRoute] string email)
    {
        var getEntrepreneurByEmailQuery = new GetCleaningEntrepreneurByEmailQuery(email);
        var entrepreneur = await entrepreneurQueryService.Handle(getEntrepreneurByEmailQuery);
        if (entrepreneur is null) return BadRequest();
        var resource = CleaningEntrepreneurResourceFromEntityAssembler.ToResourceFromEntity(entrepreneur);
        return Ok(resource);
    }
}