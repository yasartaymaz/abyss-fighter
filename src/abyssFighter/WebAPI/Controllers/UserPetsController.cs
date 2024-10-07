using Application.Features.UserPets.Commands.Create;
using Application.Features.UserPets.Commands.Delete;
using Application.Features.UserPets.Commands.Update;
using Application.Features.UserPets.Queries.GetById;
using Application.Features.UserPets.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserPetsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserPetResponse>> Add([FromBody] CreateUserPetCommand command)
    {
        CreatedUserPetResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserPetResponse>> Update([FromBody] UpdateUserPetCommand command)
    {
        UpdatedUserPetResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserPetResponse>> Delete([FromRoute] Guid id)
    {
        DeleteUserPetCommand command = new() { Id = id };

        DeletedUserPetResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserPetResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdUserPetQuery query = new() { Id = id };

        GetByIdUserPetResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListUserPetListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserPetQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserPetListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}