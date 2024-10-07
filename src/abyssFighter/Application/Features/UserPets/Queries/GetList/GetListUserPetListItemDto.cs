using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserPets.Queries.GetList;

public class GetListUserPetListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DefinitionPetId { get; set; }
    public decimal HealthPoints { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
}