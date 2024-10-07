using Application.Features.DefinitionItemTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionItemTypes.Queries.GetById;

public class GetByIdDefinitionItemTypeQuery : IRequest<GetByIdDefinitionItemTypeResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionItemTypeQueryHandler : IRequestHandler<GetByIdDefinitionItemTypeQuery, GetByIdDefinitionItemTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionItemTypeRepository _definitionItemTypeRepository;
        private readonly DefinitionItemTypeBusinessRules _definitionItemTypeBusinessRules;

        public GetByIdDefinitionItemTypeQueryHandler(IMapper mapper, IDefinitionItemTypeRepository definitionItemTypeRepository, DefinitionItemTypeBusinessRules definitionItemTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionItemTypeRepository = definitionItemTypeRepository;
            _definitionItemTypeBusinessRules = definitionItemTypeBusinessRules;
        }

        public async Task<GetByIdDefinitionItemTypeResponse> Handle(GetByIdDefinitionItemTypeQuery request, CancellationToken cancellationToken)
        {
            DefinitionItemType? definitionItemType = await _definitionItemTypeRepository.GetAsync(predicate: dit => dit.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionItemTypeBusinessRules.DefinitionItemTypeShouldExistWhenSelected(definitionItemType);

            GetByIdDefinitionItemTypeResponse response = _mapper.Map<GetByIdDefinitionItemTypeResponse>(definitionItemType);
            return response;
        }
    }
}