using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionHeroClasses.Commands.Update;

public class UpdatedDefinitionHeroClassResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public decimal HealthPoints { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
    public decimal AttackSpeedMultiplier { get; set; }
    public Guid? DefaultPetId { get; set; }
}