using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionItemTypes.Commands.Create;

public class CreatedDefinitionItemTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}