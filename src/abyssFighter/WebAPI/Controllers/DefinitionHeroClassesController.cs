using Application.Features.DefinitionHeroClasses.Commands.Create;
using Application.Features.DefinitionHeroClasses.Commands.Delete;
using Application.Features.DefinitionHeroClasses.Commands.Update;
using Application.Features.DefinitionHeroClasses.Queries.GetById;
using Application.Features.DefinitionHeroClasses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionHeroClassesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionHeroClassResponse>> Add([FromBody] CreateDefinitionHeroClassCommand command)
    {
        CreatedDefinitionHeroClassResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionHeroClassResponse>> Update([FromBody] UpdateDefinitionHeroClassCommand command)
    {
        UpdatedDefinitionHeroClassResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionHeroClassResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionHeroClassCommand command = new() { Id = id };

        DeletedDefinitionHeroClassResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionHeroClassResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionHeroClassQuery query = new() { Id = id };

        GetByIdDefinitionHeroClassResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionHeroClassListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionHeroClassQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionHeroClassListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}