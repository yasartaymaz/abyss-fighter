using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionPets.Queries.GetList;

public class GetListDefinitionPetListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid DefinitionPetTypeId { get; set; }
    public string? Name { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
    public decimal HealthPoints { get; set; }
}