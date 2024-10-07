using Application.Features.DefinitionItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionItems.Queries.GetById;

public class GetByIdDefinitionItemQuery : IRequest<GetByIdDefinitionItemResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionItemQueryHandler : IRequestHandler<GetByIdDefinitionItemQuery, GetByIdDefinitionItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionItemRepository _definitionItemRepository;
        private readonly DefinitionItemBusinessRules _definitionItemBusinessRules;

        public GetByIdDefinitionItemQueryHandler(IMapper mapper, IDefinitionItemRepository definitionItemRepository, DefinitionItemBusinessRules definitionItemBusinessRules)
        {
            _mapper = mapper;
            _definitionItemRepository = definitionItemRepository;
            _definitionItemBusinessRules = definitionItemBusinessRules;
        }

        public async Task<GetByIdDefinitionItemResponse> Handle(GetByIdDefinitionItemQuery request, CancellationToken cancellationToken)
        {
            DefinitionItem? definitionItem = await _definitionItemRepository.GetAsync(predicate: di => di.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionItemBusinessRules.DefinitionItemShouldExistWhenSelected(definitionItem);

            GetByIdDefinitionItemResponse response = _mapper.Map<GetByIdDefinitionItemResponse>(definitionItem);
            return response;
        }
    }
}