using Application.Features.DefinitionWalletTypes.Commands.Create;
using Application.Features.DefinitionWalletTypes.Commands.Delete;
using Application.Features.DefinitionWalletTypes.Commands.Update;
using Application.Features.DefinitionWalletTypes.Queries.GetById;
using Application.Features.DefinitionWalletTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DefinitionWalletTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDefinitionWalletTypeResponse>> Add([FromBody] CreateDefinitionWalletTypeCommand command)
    {
        CreatedDefinitionWalletTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDefinitionWalletTypeResponse>> Update([FromBody] UpdateDefinitionWalletTypeCommand command)
    {
        UpdatedDefinitionWalletTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDefinitionWalletTypeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDefinitionWalletTypeCommand command = new() { Id = id };

        DeletedDefinitionWalletTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDefinitionWalletTypeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDefinitionWalletTypeQuery query = new() { Id = id };

        GetByIdDefinitionWalletTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListDefinitionWalletTypeListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDefinitionWalletTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDefinitionWalletTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}