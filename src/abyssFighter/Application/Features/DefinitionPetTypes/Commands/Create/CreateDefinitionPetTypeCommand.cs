using Application.Features.DefinitionPetTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionPetTypes.Commands.Create;

public class CreateDefinitionPetTypeCommand : IRequest<CreatedDefinitionPetTypeResponse>
{
    public string? Value { get; set; }
    public required bool IsAttack { get; set; }
    public required bool IsDefence { get; set; }
    public required bool IsHybrid { get; set; }

    public class CreateDefinitionPetTypeCommandHandler : IRequestHandler<CreateDefinitionPetTypeCommand, CreatedDefinitionPetTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionPetTypeRepository _definitionPetTypeRepository;
        private readonly DefinitionPetTypeBusinessRules _definitionPetTypeBusinessRules;

        public CreateDefinitionPetTypeCommandHandler(IMapper mapper, IDefinitionPetTypeRepository definitionPetTypeRepository,
                                         DefinitionPetTypeBusinessRules definitionPetTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionPetTypeRepository = definitionPetTypeRepository;
            _definitionPetTypeBusinessRules = definitionPetTypeBusinessRules;
        }

        public async Task<CreatedDefinitionPetTypeResponse> Handle(CreateDefinitionPetTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionPetType definitionPetType = _mapper.Map<DefinitionPetType>(request);

            await _definitionPetTypeRepository.AddAsync(definitionPetType);

            CreatedDefinitionPetTypeResponse response = _mapper.Map<CreatedDefinitionPetTypeResponse>(definitionPetType);
            return response;
        }
    }
}