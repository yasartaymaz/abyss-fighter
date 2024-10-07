using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionArmorParts.Commands.Delete;

public class DeletedDefinitionArmorPartResponse : IResponse
{
    public Guid Id { get; set; }
}