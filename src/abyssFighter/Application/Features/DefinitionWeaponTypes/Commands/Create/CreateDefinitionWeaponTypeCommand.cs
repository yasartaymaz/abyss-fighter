using Application.Features.DefinitionWeaponTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWeaponTypes.Commands.Create;

public class CreateDefinitionWeaponTypeCommand : IRequest<CreatedDefinitionWeaponTypeResponse>
{
    public string? Value { get; set; }
    public required bool IsOneHanded { get; set; }

    public class CreateDefinitionWeaponTypeCommandHandler : IRequestHandler<CreateDefinitionWeaponTypeCommand, CreatedDefinitionWeaponTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWeaponTypeRepository _definitionWeaponTypeRepository;
        private readonly DefinitionWeaponTypeBusinessRules _definitionWeaponTypeBusinessRules;

        public CreateDefinitionWeaponTypeCommandHandler(IMapper mapper, IDefinitionWeaponTypeRepository definitionWeaponTypeRepository,
                                         DefinitionWeaponTypeBusinessRules definitionWeaponTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionWeaponTypeRepository = definitionWeaponTypeRepository;
            _definitionWeaponTypeBusinessRules = definitionWeaponTypeBusinessRules;
        }

        public async Task<CreatedDefinitionWeaponTypeResponse> Handle(CreateDefinitionWeaponTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionWeaponType definitionWeaponType = _mapper.Map<DefinitionWeaponType>(request);

            await _definitionWeaponTypeRepository.AddAsync(definitionWeaponType);

            CreatedDefinitionWeaponTypeResponse response = _mapper.Map<CreatedDefinitionWeaponTypeResponse>(definitionWeaponType);
            return response;
        }
    }
}