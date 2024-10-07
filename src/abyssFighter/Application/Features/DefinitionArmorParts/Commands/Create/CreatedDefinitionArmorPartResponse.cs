using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionArmorParts.Commands.Create;

public class CreatedDefinitionArmorPartResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}