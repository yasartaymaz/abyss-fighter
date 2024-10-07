using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionArmorTypes.Commands.Create;

public class CreatedDefinitionArmorTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}