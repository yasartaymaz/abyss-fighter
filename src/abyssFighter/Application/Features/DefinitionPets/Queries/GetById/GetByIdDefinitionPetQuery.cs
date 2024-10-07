using Application.Features.DefinitionPets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionPets.Queries.GetById;

public class GetByIdDefinitionPetQuery : IRequest<GetByIdDefinitionPetResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionPetQueryHandler : IRequestHandler<GetByIdDefinitionPetQuery, GetByIdDefinitionPetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionPetRepository _definitionPetRepository;
        private readonly DefinitionPetBusinessRules _definitionPetBusinessRules;

        public GetByIdDefinitionPetQueryHandler(IMapper mapper, IDefinitionPetRepository definitionPetRepository, DefinitionPetBusinessRules definitionPetBusinessRules)
        {
            _mapper = mapper;
            _definitionPetRepository = definitionPetRepository;
            _definitionPetBusinessRules = definitionPetBusinessRules;
        }

        public async Task<GetByIdDefinitionPetResponse> Handle(GetByIdDefinitionPetQuery request, CancellationToken cancellationToken)
        {
            DefinitionPet? definitionPet = await _definitionPetRepository.GetAsync(predicate: dp => dp.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionPetBusinessRules.DefinitionPetShouldExistWhenSelected(definitionPet);

            GetByIdDefinitionPetResponse response = _mapper.Map<GetByIdDefinitionPetResponse>(definitionPet);
            return response;
        }
    }
}