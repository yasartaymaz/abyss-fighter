using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionWeaponTypes.Queries.GetById;

public class GetByIdDefinitionWeaponTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public bool IsOneHanded { get; set; }
}