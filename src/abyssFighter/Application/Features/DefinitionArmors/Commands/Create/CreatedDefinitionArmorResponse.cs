using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionArmors.Commands.Create;

public class CreatedDefinitionArmorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid DefinitionArmorTypeId { get; set; }
    public Guid DefinitionArmorPartId { get; set; }
    public string? Name { get; set; }
    public decimal DefencePoints { get; set; }
}