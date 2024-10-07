using Application.Features.DefinitionPets.Constants;
using Application.Features.DefinitionPets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionPets.Commands.Delete;

public class DeleteDefinitionPetCommand : IRequest<DeletedDefinitionPetResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionPetCommandHandler : IRequestHandler<DeleteDefinitionPetCommand, DeletedDefinitionPetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionPetRepository _definitionPetRepository;
        private readonly DefinitionPetBusinessRules _definitionPetBusinessRules;

        public DeleteDefinitionPetCommandHandler(IMapper mapper, IDefinitionPetRepository definitionPetRepository,
                                         DefinitionPetBusinessRules definitionPetBusinessRules)
        {
            _mapper = mapper;
            _definitionPetRepository = definitionPetRepository;
            _definitionPetBusinessRules = definitionPetBusinessRules;
        }

        public async Task<DeletedDefinitionPetResponse> Handle(DeleteDefinitionPetCommand request, CancellationToken cancellationToken)
        {
            DefinitionPet? definitionPet = await _definitionPetRepository.GetAsync(predicate: dp => dp.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionPetBusinessRules.DefinitionPetShouldExistWhenSelected(definitionPet);

            await _definitionPetRepository.DeleteAsync(definitionPet!);

            DeletedDefinitionPetResponse response = _mapper.Map<DeletedDefinitionPetResponse>(definitionPet);
            return response;
        }
    }
}