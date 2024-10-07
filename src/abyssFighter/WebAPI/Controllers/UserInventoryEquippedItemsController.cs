using Application.Features.UserInventoryEquippedItems.Commands.Create;
using Application.Features.UserInventoryEquippedItems.Commands.Delete;
using Application.Features.UserInventoryEquippedItems.Commands.Update;
using Application.Features.UserInventoryEquippedItems.Queries.GetById;
using Application.Features.UserInventoryEquippedItems.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserInventoryEquippedItemsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserInventoryEquippedItemResponse>> Add([FromBody] CreateUserInventoryEquippedItemCommand command)
    {
        CreatedUserInventoryEquippedItemResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserInventoryEquippedItemResponse>> Update([FromBody] UpdateUserInventoryEquippedItemCommand command)
    {
        UpdatedUserInventoryEquippedItemResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserInventoryEquippedItemResponse>> Delete([FromRoute] Guid id)
    {
        DeleteUserInventoryEquippedItemCommand command = new() { Id = id };

        DeletedUserInventoryEquippedItemResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserInventoryEquippedItemResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdUserInventoryEquippedItemQuery query = new() { Id = id };

        GetByIdUserInventoryEquippedItemResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListUserInventoryEquippedItemListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserInventoryEquippedItemQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserInventoryEquippedItemListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}