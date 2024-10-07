using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserHeroes.Queries.GetById;

public class GetByIdUserHeroResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? Name { get; set; }
    public Guid DefinitionHeroClassId { get; set; }
}