using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionArmors.Commands.Delete;

public class DeletedDefinitionArmorResponse : IResponse
{
    public Guid Id { get; set; }
}