using Application.Features.UserPetDetails.Commands.Create;
using Application.Features.UserPetDetails.Commands.Delete;
using Application.Features.UserPetDetails.Commands.Update;
using Application.Features.UserPetDetails.Queries.GetById;
using Application.Features.UserPetDetails.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserPetDetailsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserPetDetailResponse>> Add([FromBody] CreateUserPetDetailCommand command)
    {
        CreatedUserPetDetailResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserPetDetailResponse>> Update([FromBody] UpdateUserPetDetailCommand command)
    {
        UpdatedUserPetDetailResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserPetDetailResponse>> Delete([FromRoute] Guid id)
    {
        DeleteUserPetDetailCommand command = new() { Id = id };

        DeletedUserPetDetailResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserPetDetailResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdUserPetDetailQuery query = new() { Id = id };

        GetByIdUserPetDetailResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListUserPetDetailListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserPetDetailQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserPetDetailListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}