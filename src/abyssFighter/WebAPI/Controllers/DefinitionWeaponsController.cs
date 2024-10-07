using Application.Features.DefinitionWeapons.Commands.Create;
using Application.Features.DefinitionWeapons.Commands.Delete;
using Application.Features.DefinitionWeapons.Commands.Update;
using Application.Features.DefinitionWeapons.Queries.GetById;
using Application.Features.DefinitionWeapons.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionWeaponsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionWeaponResponse>> Add([FromBody] CreateDefinitionWeaponCommand command)
    {
        CreatedDefinitionWeaponResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionWeaponResponse>> Update([FromBody] UpdateDefinitionWeaponCommand command)
    {
        UpdatedDefinitionWeaponResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionWeaponResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionWeaponCommand command = new() { Id = id };

        DeletedDefinitionWeaponResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionWeaponResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionWeaponQuery query = new() { Id = id };

        GetByIdDefinitionWeaponResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionWeaponListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionWeaponQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionWeaponListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}