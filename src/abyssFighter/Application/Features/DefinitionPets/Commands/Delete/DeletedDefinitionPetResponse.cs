using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionPets.Commands.Delete;

public class DeletedDefinitionPetResponse : IResponse
{
    public Guid Id { get; set; }
}