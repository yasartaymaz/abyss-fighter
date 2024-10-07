using Application.Features.DefinitionItemTypes.Commands.Create;
using Application.Features.DefinitionItemTypes.Commands.Delete;
using Application.Features.DefinitionItemTypes.Commands.Update;
using Application.Features.DefinitionItemTypes.Queries.GetById;
using Application.Features.DefinitionItemTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionItemTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionItemTypeResponse>> Add([FromBody] CreateDefinitionItemTypeCommand command)
    {
        CreatedDefinitionItemTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionItemTypeResponse>> Update([FromBody] UpdateDefinitionItemTypeCommand command)
    {
        UpdatedDefinitionItemTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionItemTypeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionItemTypeCommand command = new() { Id = id };

        DeletedDefinitionItemTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionItemTypeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionItemTypeQuery query = new() { Id = id };

        GetByIdDefinitionItemTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionItemTypeListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionItemTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionItemTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}