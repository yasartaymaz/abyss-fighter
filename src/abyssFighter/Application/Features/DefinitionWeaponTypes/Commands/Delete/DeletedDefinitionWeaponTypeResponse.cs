using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionWeaponTypes.Commands.Delete;

public class DeletedDefinitionWeaponTypeResponse : IResponse
{
    public Guid Id { get; set; }
}