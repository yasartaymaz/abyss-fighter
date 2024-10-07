using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionPets.Queries.GetById;

public class GetByIdDefinitionPetResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid DefinitionPetTypeId { get; set; }
    public string? Name { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
    public decimal HealthPoints { get; set; }
}