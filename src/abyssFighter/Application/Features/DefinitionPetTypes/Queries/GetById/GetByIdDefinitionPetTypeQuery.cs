using Application.Features.DefinitionPetTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionPetTypes.Queries.GetById;

public class GetByIdDefinitionPetTypeQuery : IRequest<GetByIdDefinitionPetTypeResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionPetTypeQueryHandler : IRequestHandler<GetByIdDefinitionPetTypeQuery, GetByIdDefinitionPetTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionPetTypeRepository _definitionPetTypeRepository;
        private readonly DefinitionPetTypeBusinessRules _definitionPetTypeBusinessRules;

        public GetByIdDefinitionPetTypeQueryHandler(IMapper mapper, IDefinitionPetTypeRepository definitionPetTypeRepository, DefinitionPetTypeBusinessRules definitionPetTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionPetTypeRepository = definitionPetTypeRepository;
            _definitionPetTypeBusinessRules = definitionPetTypeBusinessRules;
        }

        public async Task<GetByIdDefinitionPetTypeResponse> Handle(GetByIdDefinitionPetTypeQuery request, CancellationToken cancellationToken)
        {
            DefinitionPetType? definitionPetType = await _definitionPetTypeRepository.GetAsync(predicate: dpt => dpt.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionPetTypeBusinessRules.DefinitionPetTypeShouldExistWhenSelected(definitionPetType);

            GetByIdDefinitionPetTypeResponse response = _mapper.Map<GetByIdDefinitionPetTypeResponse>(definitionPetType);
            return response;
        }
    }
}