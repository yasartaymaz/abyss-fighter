using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionArmorTypes.Commands.Delete;

public class DeletedDefinitionArmorTypeResponse : IResponse
{
    public Guid Id { get; set; }
}