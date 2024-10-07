using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionPetTypes.Commands.Update;

public class UpdatedDefinitionPetTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public bool IsAttack { get; set; }
    public bool IsDefence { get; set; }
    public bool IsHybrid { get; set; }
}