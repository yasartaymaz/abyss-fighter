using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionPets.Commands.Update;

public class UpdatedDefinitionPetResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid DefinitionPetTypeId { get; set; }
    public string? Name { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
    public decimal HealthPoints { get; set; }
}