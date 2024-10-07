using NArchitecture.Core.Application.Responses;

namespace Application.Features.DefinitionItemTypes.Queries.GetById;

public class GetByIdDefinitionItemTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
}