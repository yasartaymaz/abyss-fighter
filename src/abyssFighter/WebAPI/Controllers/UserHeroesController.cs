using Application.Features.UserHeroes.Commands.Create;
using Application.Features.UserHeroes.Commands.Delete;
using Application.Features.UserHeroes.Commands.Update;
using Application.Features.UserHeroes.Queries.GetById;
using Application.Features.UserHeroes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserHeroesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserHeroResponse>> Add([FromBody] CreateUserHeroCommand command)
    {
        CreatedUserHeroResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserHeroResponse>> Update([FromBody] UpdateUserHeroCommand command)
    {
        UpdatedUserHeroResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserHeroResponse>> Delete([FromRoute] Guid id)
    {
        DeleteUserHeroCommand command = new() { Id = id };

        DeletedUserHeroResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserHeroResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdUserHeroQuery query = new() { Id = id };

        GetByIdUserHeroResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListUserHeroListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserHeroQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserHeroListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}