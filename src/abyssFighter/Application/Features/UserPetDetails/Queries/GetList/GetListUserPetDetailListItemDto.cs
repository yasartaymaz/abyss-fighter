using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserPetDetails.Queries.GetList;

public class GetListUserPetDetailListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserPetId { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
}