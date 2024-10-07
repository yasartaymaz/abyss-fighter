using Application.Features.DefinitionPets.Commands.Create;
using Application.Features.DefinitionPets.Commands.Delete;
using Application.Features.DefinitionPets.Commands.Update;
using Application.Features.DefinitionPets.Queries.GetById;
using Application.Features.DefinitionPets.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionPetsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionPetResponse>> Add([FromBody] CreateDefinitionPetCommand command)
    {
        CreatedDefinitionPetResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionPetResponse>> Update([FromBody] UpdateDefinitionPetCommand command)
    {
        UpdatedDefinitionPetResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionPetResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionPetCommand command = new() { Id = id };

        DeletedDefinitionPetResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionPetResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionPetQuery query = new() { Id = id };

        GetByIdDefinitionPetResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionPetListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionPetQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionPetListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}