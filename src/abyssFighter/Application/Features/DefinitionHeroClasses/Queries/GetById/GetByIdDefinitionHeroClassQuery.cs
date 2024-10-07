using Application.Features.DefinitionHeroClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionHeroClasses.Queries.GetById;

public class GetByIdDefinitionHeroClassQuery : IRequest<GetByIdDefinitionHeroClassResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionHeroClassQueryHandler : IRequestHandler<GetByIdDefinitionHeroClassQuery, GetByIdDefinitionHeroClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionHeroClassRepository _definitionHeroClassRepository;
        private readonly DefinitionHeroClassBusinessRules _definitionHeroClassBusinessRules;

        public GetByIdDefinitionHeroClassQueryHandler(IMapper mapper, IDefinitionHeroClassRepository definitionHeroClassRepository, DefinitionHeroClassBusinessRules definitionHeroClassBusinessRules)
        {
            _mapper = mapper;
            _definitionHeroClassRepository = definitionHeroClassRepository;
            _definitionHeroClassBusinessRules = definitionHeroClassBusinessRules;
        }

        public async Task<GetByIdDefinitionHeroClassResponse> Handle(GetByIdDefinitionHeroClassQuery request, CancellationToken cancellationToken)
        {
            DefinitionHeroClass? definitionHeroClass = await _definitionHeroClassRepository.GetAsync(predicate: dhc => dhc.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionHeroClassBusinessRules.DefinitionHeroClassShouldExistWhenSelected(definitionHeroClass);

            GetByIdDefinitionHeroClassResponse response = _mapper.Map<GetByIdDefinitionHeroClassResponse>(definitionHeroClass);
            return response;
        }
    }
}