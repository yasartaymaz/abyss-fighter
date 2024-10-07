using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionItemTypes.Commands.Delete;

public class DeletedDefinitionItemTypeResponse : IResponse
{
    public Guid Id { get; set; }
}