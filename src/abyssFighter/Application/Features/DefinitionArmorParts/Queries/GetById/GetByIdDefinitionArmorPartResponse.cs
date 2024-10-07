using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionArmorParts.Queries.GetById;

public class GetByIdDefinitionArmorPartResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}