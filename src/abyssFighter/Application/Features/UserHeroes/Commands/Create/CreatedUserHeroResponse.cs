using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserHeroes.Commands.Create;

public class CreatedUserHeroResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? Name { get; set; }
    public Guid DefinitionHeroClassId { get; set; }
}