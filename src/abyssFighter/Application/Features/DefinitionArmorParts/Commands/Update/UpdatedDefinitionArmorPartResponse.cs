using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionArmorParts.Commands.Update;

public class UpdatedDefinitionArmorPartResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}