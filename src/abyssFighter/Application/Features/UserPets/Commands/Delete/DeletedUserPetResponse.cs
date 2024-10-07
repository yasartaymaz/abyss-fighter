using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserPets.Commands.Delete;

public class DeletedUserPetResponse : IResponse
{
    public Guid Id { get; set; }
}