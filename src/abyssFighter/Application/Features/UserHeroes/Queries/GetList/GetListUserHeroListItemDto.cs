using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserHeroes.Queries.GetList;

public class GetListUserHeroListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? Name { get; set; }
    public Guid DefinitionHeroClassId { get; set; }
}