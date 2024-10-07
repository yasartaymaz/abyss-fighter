using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionItems.Queries.GetById;

public class GetByIdDefinitionItemResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid DefinitionItemTypeId { get; set; }
    public Guid ItemId { get; set; }
    public bool IsStackable { get; set; }
    public bool IsWeapon { get; set; }
    public bool IsArmor { get; set; }
}