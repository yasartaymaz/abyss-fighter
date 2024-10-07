using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionWeaponTypes.Commands.Create;

public class CreatedDefinitionWeaponTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public bool IsOneHanded { get; set; }
}