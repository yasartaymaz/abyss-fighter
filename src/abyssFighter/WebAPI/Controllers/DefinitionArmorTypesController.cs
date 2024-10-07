using Application.Features.DefinitionArmorTypes.Commands.Create;
using Application.Features.DefinitionArmorTypes.Commands.Delete;
using Application.Features.DefinitionArmorTypes.Commands.Update;
using Application.Features.DefinitionArmorTypes.Queries.GetById;
using Application.Features.DefinitionArmorTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionArmorTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionArmorTypeResponse>> Add([FromBody] CreateDefinitionArmorTypeCommand command)
    {
        CreatedDefinitionArmorTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionArmorTypeResponse>> Update([FromBody] UpdateDefinitionArmorTypeCommand command)
    {
        UpdatedDefinitionArmorTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionArmorTypeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionArmorTypeCommand command = new() { Id = id };

        DeletedDefinitionArmorTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionArmorTypeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionArmorTypeQuery query = new() { Id = id };

        GetByIdDefinitionArmorTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionArmorTypeListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionArmorTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionArmorTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}