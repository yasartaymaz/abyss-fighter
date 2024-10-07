using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionHeroClasses.Commands.Delete;

public class DeletedDefinitionHeroClassResponse : IResponse
{
    public Guid Id { get; set; }
}