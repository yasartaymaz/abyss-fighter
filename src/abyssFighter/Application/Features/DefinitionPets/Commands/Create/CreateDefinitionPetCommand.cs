using Application.Features.DefinitionPets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionPets.Commands.Create;

public class CreateDefinitionPetCommand : IRequest<CreatedDefinitionPetResponse>
{
    public required Guid DefinitionPetTypeId { get; set; }
    public string? Name { get; set; }
    public required decimal AttackPoints { get; set; }
    public required decimal DefencePoints { get; set; }
    public required decimal HealthPoints { get; set; }

    public class CreateDefinitionPetCommandHandler : IRequestHandler<CreateDefinitionPetCommand, CreatedDefinitionPetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionPetRepository _definitionPetRepository;
        private readonly DefinitionPetBusinessRules _definitionPetBusinessRules;

        public CreateDefinitionPetCommandHandler(IMapper mapper, IDefinitionPetRepository definitionPetRepository,
                                         DefinitionPetBusinessRules definitionPetBusinessRules)
        {
            _mapper = mapper;
            _definitionPetRepository = definitionPetRepository;
            _definitionPetBusinessRules = definitionPetBusinessRules;
        }

        public async Task<CreatedDefinitionPetResponse> Handle(CreateDefinitionPetCommand request, CancellationToken cancellationToken)
        {
            DefinitionPet definitionPet = _mapper.Map<DefinitionPet>(request);

            await _definitionPetRepository.AddAsync(definitionPet);

            CreatedDefinitionPetResponse response = _mapper.Map<CreatedDefinitionPetResponse>(definitionPet);
            return response;
        }
    }
}