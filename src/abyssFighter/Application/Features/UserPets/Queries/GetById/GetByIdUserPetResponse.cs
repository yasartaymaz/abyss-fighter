using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserPets.Queries.GetById;

public class GetByIdUserPetResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DefinitionPetId { get; set; }
    public decimal HealthPoints { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
}