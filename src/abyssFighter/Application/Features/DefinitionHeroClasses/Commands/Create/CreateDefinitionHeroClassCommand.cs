using Application.Features.DefinitionHeroClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionHeroClasses.Commands.Create;

public class CreateDefinitionHeroClassCommand : IRequest<CreatedDefinitionHeroClassResponse>
{
    public string? Value { get; set; }
    public required decimal HealthPoints { get; set; }
    public required decimal AttackPoints { get; set; }
    public required decimal DefencePoints { get; set; }
    public required decimal AttackSpeedMultiplier { get; set; }
    public Guid? DefaultPetId { get; set; }

    public class CreateDefinitionHeroClassCommandHandler : IRequestHandler<CreateDefinitionHeroClassCommand, CreatedDefinitionHeroClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionHeroClassRepository _definitionHeroClassRepository;
        private readonly DefinitionHeroClassBusinessRules _definitionHeroClassBusinessRules;

        public CreateDefinitionHeroClassCommandHandler(IMapper mapper, IDefinitionHeroClassRepository definitionHeroClassRepository,
                                         DefinitionHeroClassBusinessRules definitionHeroClassBusinessRules)
        {
            _mapper = mapper;
            _definitionHeroClassRepository = definitionHeroClassRepository;
            _definitionHeroClassBusinessRules = definitionHeroClassBusinessRules;
        }

        public async Task<CreatedDefinitionHeroClassResponse> Handle(CreateDefinitionHeroClassCommand request, CancellationToken cancellationToken)
        {
            DefinitionHeroClass definitionHeroClass = _mapper.Map<DefinitionHeroClass>(request);

            await _definitionHeroClassRepository.AddAsync(definitionHeroClass);

            CreatedDefinitionHeroClassResponse response = _mapper.Map<CreatedDefinitionHeroClassResponse>(definitionHeroClass);
            return response;
        }
    }
}