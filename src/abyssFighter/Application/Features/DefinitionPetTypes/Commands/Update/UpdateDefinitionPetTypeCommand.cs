using Application.Features.DefinitionPetTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionPetTypes.Commands.Update;

public class UpdateDefinitionPetTypeCommand : IRequest<UpdatedDefinitionPetTypeResponse>
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public required bool IsAttack { get; set; }
    public required bool IsDefence { get; set; }
    public required bool IsHybrid { get; set; }

    public class UpdateDefinitionPetTypeCommandHandler : IRequestHandler<UpdateDefinitionPetTypeCommand, UpdatedDefinitionPetTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionPetTypeRepository _definitionPetTypeRepository;
        private readonly DefinitionPetTypeBusinessRules _definitionPetTypeBusinessRules;

        public UpdateDefinitionPetTypeCommandHandler(IMapper mapper, IDefinitionPetTypeRepository definitionPetTypeRepository,
                                         DefinitionPetTypeBusinessRules definitionPetTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionPetTypeRepository = definitionPetTypeRepository;
            _definitionPetTypeBusinessRules = definitionPetTypeBusinessRules;
        }

        public async Task<UpdatedDefinitionPetTypeResponse> Handle(UpdateDefinitionPetTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionPetType? definitionPetType = await _definitionPetTypeRepository.GetAsync(predicate: dpt => dpt.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionPetTypeBusinessRules.DefinitionPetTypeShouldExistWhenSelected(definitionPetType);
            definitionPetType = _mapper.Map(request, definitionPetType);

            await _definitionPetTypeRepository.UpdateAsync(definitionPetType!);

            UpdatedDefinitionPetTypeResponse response = _mapper.Map<UpdatedDefinitionPetTypeResponse>(definitionPetType);
            return response;
        }
    }
}