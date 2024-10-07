using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionWeapons.Commands.Delete;

public class DeletedDefinitionWeaponResponse : IResponse
{
    public Guid Id { get; set; }
}