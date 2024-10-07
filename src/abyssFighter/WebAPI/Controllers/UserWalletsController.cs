using Application.Features.UserWallets.Commands.Create;
using Application.Features.UserWallets.Commands.Delete;
using Application.Features.UserWallets.Commands.Update;
using Application.Features.UserWallets.Queries.GetById;
using Application.Features.UserWallets.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserWalletsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserWalletResponse>> Add([FromBody] CreateUserWalletCommand command)
    {
        CreatedUserWalletResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserWalletResponse>> Update([FromBody] UpdateUserWalletCommand command)
    {
        UpdatedUserWalletResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserWalletResponse>> Delete([FromRoute] Guid id)
    {
        DeleteUserWalletCommand command = new() { Id = id };

        DeletedUserWalletResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserWalletResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdUserWalletQuery query = new() { Id = id };

        GetByIdUserWalletResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListUserWalletListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserWalletQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserWalletListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}