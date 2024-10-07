using Application.Features.DefinitionPets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionPets.Commands.Update;

public class UpdateDefinitionPetCommand : IRequest<UpdatedDefinitionPetResponse>
{
    public Guid Id { get; set; }
    public required Guid DefinitionPetTypeId { get; set; }
    public string? Name { get; set; }
    public required decimal AttackPoints { get; set; }
    public required decimal DefencePoints { get; set; }
    public required decimal HealthPoints { get; set; }

    public class UpdateDefinitionPetCommandHandler : IRequestHandler<UpdateDefinitionPetCommand, UpdatedDefinitionPetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionPetRepository _definitionPetRepository;
        private readonly DefinitionPetBusinessRules _definitionPetBusinessRules;

        public UpdateDefinitionPetCommandHandler(IMapper mapper, IDefinitionPetRepository definitionPetRepository,
                                         DefinitionPetBusinessRules definitionPetBusinessRules)
        {
            _mapper = mapper;
            _definitionPetRepository = definitionPetRepository;
            _definitionPetBusinessRules = definitionPetBusinessRules;
        }

        public async Task<UpdatedDefinitionPetResponse> Handle(UpdateDefinitionPetCommand request, CancellationToken cancellationToken)
        {
            DefinitionPet? definitionPet = await _definitionPetRepository.GetAsync(predicate: dp => dp.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionPetBusinessRules.DefinitionPetShouldExistWhenSelected(definitionPet);
            definitionPet = _mapper.Map(request, definitionPet);

            await _definitionPetRepository.UpdateAsync(definitionPet!);

            UpdatedDefinitionPetResponse response = _mapper.Map<UpdatedDefinitionPetResponse>(definitionPet);
            return response;
        }
    }
}