using Application.Features.DefinitionHeroClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionHeroClasses.Commands.Update;

public class UpdateDefinitionHeroClassCommand : IRequest<UpdatedDefinitionHeroClassResponse>
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public required decimal HealthPoints { get; set; }
    public required decimal AttackPoints { get; set; }
    public required decimal DefencePoints { get; set; }
    public required decimal AttackSpeedMultiplier { get; set; }
    public Guid? DefaultPetId { get; set; }

    public class UpdateDefinitionHeroClassCommandHandler : IRequestHandler<UpdateDefinitionHeroClassCommand, UpdatedDefinitionHeroClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionHeroClassRepository _definitionHeroClassRepository;
        private readonly DefinitionHeroClassBusinessRules _definitionHeroClassBusinessRules;

        public UpdateDefinitionHeroClassCommandHandler(IMapper mapper, IDefinitionHeroClassRepository definitionHeroClassRepository,
                                         DefinitionHeroClassBusinessRules definitionHeroClassBusinessRules)
        {
            _mapper = mapper;
            _definitionHeroClassRepository = definitionHeroClassRepository;
            _definitionHeroClassBusinessRules = definitionHeroClassBusinessRules;
        }

        public async Task<UpdatedDefinitionHeroClassResponse> Handle(UpdateDefinitionHeroClassCommand request, CancellationToken cancellationToken)
        {
            DefinitionHeroClass? definitionHeroClass = await _definitionHeroClassRepository.GetAsync(predicate: dhc => dhc.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionHeroClassBusinessRules.DefinitionHeroClassShouldExistWhenSelected(definitionHeroClass);
            definitionHeroClass = _mapper.Map(request, definitionHeroClass);

            await _definitionHeroClassRepository.UpdateAsync(definitionHeroClass!);

            UpdatedDefinitionHeroClassResponse response = _mapper.Map<UpdatedDefinitionHeroClassResponse>(definitionHeroClass);
            return response;
        }
    }
}