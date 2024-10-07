using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserInventories.Commands.Create;

public class CreatedUserInventoryResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid UserHeroId { get; set; }
    public Guid DefinitionItemId { get; set; }
    public Guid DefinitionItemTypeId { get; set; }
    public decimal Amount { get; set; }
}