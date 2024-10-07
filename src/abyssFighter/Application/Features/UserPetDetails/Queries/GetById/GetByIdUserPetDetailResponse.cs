using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserPetDetails.Queries.GetById;

public class GetByIdUserPetDetailResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserPetId { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
}