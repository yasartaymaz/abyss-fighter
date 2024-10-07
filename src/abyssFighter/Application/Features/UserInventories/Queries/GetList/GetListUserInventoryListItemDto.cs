using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserInventories.Queries.GetList;

public class GetListUserInventoryListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UserHeroId { get; set; }
    public Guid DefinitionItemId { get; set; }
    public Guid DefinitionItemTypeId { get; set; }
    public decimal Amount { get; set; }
}