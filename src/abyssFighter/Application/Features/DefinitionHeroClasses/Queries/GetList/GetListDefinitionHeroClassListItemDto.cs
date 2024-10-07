using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionHeroClasses.Queries.GetList;

public class GetListDefinitionHeroClassListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public decimal HealthPoints { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
    public decimal AttackSpeedMultiplier { get; set; }
    public Guid? DefaultPetId { get; set; }
}