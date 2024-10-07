using Application.Features.DefinitionPetTypes.Constants;
using Application.Features.DefinitionPetTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionPetTypes.Commands.Delete;

public class DeleteDefinitionPetTypeCommand : IRequest<DeletedDefinitionPetTypeResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionPetTypeCommandHandler : IRequestHandler<DeleteDefinitionPetTypeCommand, DeletedDefinitionPetTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionPetTypeRepository _definitionPetTypeRepository;
        private readonly DefinitionPetTypeBusinessRules _definitionPetTypeBusinessRules;

        public DeleteDefinitionPetTypeCommandHandler(IMapper mapper, IDefinitionPetTypeRepository definitionPetTypeRepository,
                                         DefinitionPetTypeBusinessRules definitionPetTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionPetTypeRepository = definitionPetTypeRepository;
            _definitionPetTypeBusinessRules = definitionPetTypeBusinessRules;
        }

        public async Task<DeletedDefinitionPetTypeResponse> Handle(DeleteDefinitionPetTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionPetType? definitionPetType = await _definitionPetTypeRepository.GetAsync(predicate: dpt => dpt.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionPetTypeBusinessRules.DefinitionPetTypeShouldExistWhenSelected(definitionPetType);

            await _definitionPetTypeRepository.DeleteAsync(definitionPetType!);

            DeletedDefinitionPetTypeResponse response = _mapper.Map<DeletedDefinitionPetTypeResponse>(definitionPetType);
            return response;
        }
    }
}