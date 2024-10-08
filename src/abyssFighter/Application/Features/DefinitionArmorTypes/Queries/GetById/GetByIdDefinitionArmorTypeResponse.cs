using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionArmorTypes.Queries.GetById;

public class GetByIdDefinitionArmorTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public Guid HeroClassId { get; set; }
}