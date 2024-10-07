using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionItemTypes.Commands.Update;

public class UpdatedDefinitionItemTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}