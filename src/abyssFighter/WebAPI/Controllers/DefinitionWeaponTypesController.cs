using Application.Features.DefinitionWeaponTypes.Commands.Create;
using Application.Features.DefinitionWeaponTypes.Commands.Delete;
using Application.Features.DefinitionWeaponTypes.Commands.Update;
using Application.Features.DefinitionWeaponTypes.Queries.GetById;
using Application.Features.DefinitionWeaponTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionWeaponTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionWeaponTypeResponse>> Add([FromBody] CreateDefinitionWeaponTypeCommand command)
    {
        CreatedDefinitionWeaponTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionWeaponTypeResponse>> Update([FromBody] UpdateDefinitionWeaponTypeCommand command)
    {
        UpdatedDefinitionWeaponTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionWeaponTypeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionWeaponTypeCommand command = new() { Id = id };

        DeletedDefinitionWeaponTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionWeaponTypeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionWeaponTypeQuery query = new() { Id = id };

        GetByIdDefinitionWeaponTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionWeaponTypeListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionWeaponTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionWeaponTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}