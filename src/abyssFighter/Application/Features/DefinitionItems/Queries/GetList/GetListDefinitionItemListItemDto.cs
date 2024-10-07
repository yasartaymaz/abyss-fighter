using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DefinitionItems.Queries.GetList;

public class GetListDefinitionItemListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid DefinitionItemTypeId { get; set; }
    public Guid ItemId { get; set; }
    public bool IsStackable { get; set; }
    public bool IsWeapon { get; set; }
    public bool IsArmor { get; set; }
}