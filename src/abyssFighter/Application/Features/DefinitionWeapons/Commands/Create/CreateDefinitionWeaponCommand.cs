using Application.Features.DefinitionWeapons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWeapons.Commands.Create;

public class CreateDefinitionWeaponCommand : IRequest<CreatedDefinitionWeaponResponse>
{
    public required Guid DefinitionWeaponTypeId { get; set; }
    public string? Name { get; set; }
    public required bool IsOneHanded { get; set; }
    public required decimal AttackPoints { get; set; }
    public required decimal AttackSpeedMultiplier { get; set; }

    public class CreateDefinitionWeaponCommandHandler : IRequestHandler<CreateDefinitionWeaponCommand, CreatedDefinitionWeaponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWeaponRepository _definitionWeaponRepository;
        private readonly DefinitionWeaponBusinessRules _definitionWeaponBusinessRules;

        public CreateDefinitionWeaponCommandHandler(IMapper mapper, IDefinitionWeaponRepository definitionWeaponRepository,
                                         DefinitionWeaponBusinessRules definitionWeaponBusinessRules)
        {
            _mapper = mapper;
            _definitionWeaponRepository = definitionWeaponRepository;
            _definitionWeaponBusinessRules = definitionWeaponBusinessRules;
        }

        public async Task<CreatedDefinitionWeaponResponse> Handle(CreateDefinitionWeaponCommand request, CancellationToken cancellationToken)
        {
            DefinitionWeapon definitionWeapon = _mapper.Map<DefinitionWeapon>(request);

            await _definitionWeaponRepository.AddAsync(definitionWeapon);

            CreatedDefinitionWeaponResponse response = _mapper.Map<CreatedDefinitionWeaponResponse>(definitionWeapon);
            return response;
        }
    }
}