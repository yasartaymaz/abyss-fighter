using Application.Features.DefinitionItems.Commands.Create;
using Application.Features.DefinitionItems.Commands.Delete;
using Application.Features.DefinitionItems.Commands.Update;
using Application.Features.DefinitionItems.Queries.GetById;
using Application.Features.DefinitionItems.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionItemsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionItemResponse>> Add([FromBody] CreateDefinitionItemCommand command)
    {
        CreatedDefinitionItemResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionItemResponse>> Update([FromBody] UpdateDefinitionItemCommand command)
    {
        UpdatedDefinitionItemResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionItemResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionItemCommand command = new() { Id = id };

        DeletedDefinitionItemResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionItemResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionItemQuery query = new() { Id = id };

        GetByIdDefinitionItemResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionItemListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionItemQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionItemListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}