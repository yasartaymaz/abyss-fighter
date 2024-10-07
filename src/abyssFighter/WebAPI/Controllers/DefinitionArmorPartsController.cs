using Application.Features.DefinitionArmorParts.Commands.Create;
using Application.Features.DefinitionArmorParts.Commands.Delete;
using Application.Features.DefinitionArmorParts.Commands.Update;
using Application.Features.DefinitionArmorParts.Queries.GetById;
using Application.Features.DefinitionArmorParts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionArmorPartsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionArmorPartResponse>> Add([FromBody] CreateDefinitionArmorPartCommand command)
    {
        CreatedDefinitionArmorPartResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionArmorPartResponse>> Update([FromBody] UpdateDefinitionArmorPartCommand command)
    {
        UpdatedDefinitionArmorPartResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionArmorPartResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionArmorPartCommand command = new() { Id = id };

        DeletedDefinitionArmorPartResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionArmorPartResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionArmorPartQuery query = new() { Id = id };

        GetByIdDefinitionArmorPartResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionArmorPartListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionArmorPartQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionArmorPartListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}