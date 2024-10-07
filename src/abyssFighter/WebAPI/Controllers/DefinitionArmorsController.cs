using Application.Features.DefinitionArmors.Commands.Create;
using Application.Features.DefinitionArmors.Commands.Delete;
using Application.Features.DefinitionArmors.Commands.Update;
using Application.Features.DefinitionArmors.Queries.GetById;
using Application.Features.DefinitionArmors.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionArmorsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionArmorResponse>> Add([FromBody] CreateDefinitionArmorCommand command)
    {
        CreatedDefinitionArmorResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionArmorResponse>> Update([FromBody] UpdateDefinitionArmorCommand command)
    {
        UpdatedDefinitionArmorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionArmorResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionArmorCommand command = new() { Id = id };

        DeletedDefinitionArmorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionArmorResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionArmorQuery query = new() { Id = id };

        GetByIdDefinitionArmorResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionArmorListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionArmorQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionArmorListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}