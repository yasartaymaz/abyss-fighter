using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionArmorTypes.Commands.Update;

public class UpdatedDefinitionArmorTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public Guid HeroClassId { get; set; }
}