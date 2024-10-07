using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionArmors.Queries.GetList;

public class GetListDefinitionArmorListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid DefinitionArmorTypeId { get; set; }
    public Guid DefinitionArmorPartId { get; set; }
    public string? Name { get; set; }
    public decimal DefencePoints { get; set; }
}