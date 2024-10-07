using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionItems.Commands.Delete;

public class DeletedDefinitionItemResponse : IResponse
{
    public Guid Id { get; set; }
}