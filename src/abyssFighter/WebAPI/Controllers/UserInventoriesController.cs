using Application.Features.UserInventories.Commands.Create;
using Application.Features.UserInventories.Commands.Delete;
using Application.Features.UserInventories.Commands.Update;
using Application.Features.UserInventories.Queries.GetById;
using Application.Features.UserInventories.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserInventoriesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserInventoryResponse>> Add([FromBody] CreateUserInventoryCommand command)
    {
        CreatedUserInventoryResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserInventoryResponse>> Update([FromBody] UpdateUserInventoryCommand command)
    {
        UpdatedUserInventoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserInventoryResponse>> Delete([FromRoute] Guid id)
    {
        DeleteUserInventoryCommand command = new() { Id = id };

        DeletedUserInventoryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserInventoryResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdUserInventoryQuery query = new() { Id = id };

        GetByIdUserInventoryResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListUserInventoryListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserInventoryQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserInventoryListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}