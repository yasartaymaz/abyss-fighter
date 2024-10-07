using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionWeaponTypes.Commands.Update;

public class UpdatedDefinitionWeaponTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public bool IsOneHanded { get; set; }
}