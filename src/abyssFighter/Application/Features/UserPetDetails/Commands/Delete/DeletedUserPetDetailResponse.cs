using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserPetDetails.Commands.Delete;

public class DeletedUserPetDetailResponse : IResponse
{
    public Guid Id { get; set; }
}