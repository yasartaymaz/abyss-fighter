using Application.Features.DefinitionWeapons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWeapons.Commands.Update;

public class UpdateDefinitionWeaponCommand : IRequest<UpdatedDefinitionWeaponResponse>
{
    public Guid Id { get; set; }
    public required Guid DefinitionWeaponTypeId { get; set; }
    public string? Name { get; set; }
    public required bool IsOneHanded { get; set; }
    public required decimal AttackPoints { get; set; }
    public required decimal DefencePoints { get; set; }
    public required decimal AttackSpeedMultiplier { get; set; }

    public class UpdateDefinitionWeaponCommandHandler : IRequestHandler<UpdateDefinitionWeaponCommand, UpdatedDefinitionWeaponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWeaponRepository _definitionWeaponRepository;
        private readonly DefinitionWeaponBusinessRules _definitionWeaponBusinessRules;

        public UpdateDefinitionWeaponCommandHandler(IMapper mapper, IDefinitionWeaponRepository definitionWeaponRepository,
                                         DefinitionWeaponBusinessRules definitionWeaponBusinessRules)
        {
            _mapper = mapper;
            _definitionWeaponRepository = definitionWeaponRepository;
            _definitionWeaponBusinessRules = definitionWeaponBusinessRules;
        }

        public async Task<UpdatedDefinitionWeaponResponse> Handle(UpdateDefinitionWeaponCommand request, CancellationToken cancellationToken)
        {
            DefinitionWeapon? definitionWeapon = await _definitionWeaponRepository.GetAsync(predicate: dw => dw.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionWeaponBusinessRules.DefinitionWeaponShouldExistWhenSelected(definitionWeapon);
            definitionWeapon = _mapper.Map(request, definitionWeapon);

            await _definitionWeaponRepository.UpdateAsync(definitionWeapon!);

            UpdatedDefinitionWeaponResponse response = _mapper.Map<UpdatedDefinitionWeaponResponse>(definitionWeapon);
            return response;
        }
    }
}