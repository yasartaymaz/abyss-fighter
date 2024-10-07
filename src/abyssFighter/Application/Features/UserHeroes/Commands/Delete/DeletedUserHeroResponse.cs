using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserHeroes.Commands.Delete;

public class DeletedUserHeroResponse : IResponse
{
    public Guid Id { get; set; }
}