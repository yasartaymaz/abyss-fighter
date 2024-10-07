using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionPetTypes.Commands.Delete;

public class DeletedDefinitionPetTypeResponse : IResponse
{
    public Guid Id { get; set; }
}