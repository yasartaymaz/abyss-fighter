using Application.Features.DefinitionPetTypes.Commands.Create;
using Application.Features.DefinitionPetTypes.Commands.Delete;
using Application.Features.DefinitionPetTypes.Commands.Update;
using Application.Features.DefinitionPetTypes.Queries.GetById;
using Application.Features.DefinitionPetTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionPetTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionPetTypeResponse>> Add([FromBody] CreateDefinitionPetTypeCommand command)
    {
        CreatedDefinitionPetTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionPetTypeResponse>> Update([FromBody] UpdateDefinitionPetTypeCommand command)
    {
        UpdatedDefinitionPetTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionPetTypeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionPetTypeCommand command = new() { Id = id };

        DeletedDefinitionPetTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionPetTypeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionPetTypeQuery query = new() { Id = id };

        GetByIdDefinitionPetTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionPetTypeListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionPetTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionPetTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}