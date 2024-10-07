using Application.Features.DefinitionWeaponTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWeaponTypes.Commands.Update;

public class UpdateDefinitionWeaponTypeCommand : IRequest<UpdatedDefinitionWeaponTypeResponse>
{
    public Guid Id { get; set; }
    public string? Value { get; set; }
    public required bool IsOneHanded { get; set; }

    public class UpdateDefinitionWeaponTypeCommandHandler : IRequestHandler<UpdateDefinitionWeaponTypeCommand, UpdatedDefinitionWeaponTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWeaponTypeRepository _definitionWeaponTypeRepository;
        private readonly DefinitionWeaponTypeBusinessRules _definitionWeaponTypeBusinessRules;

        public UpdateDefinitionWeaponTypeCommandHandler(IMapper mapper, IDefinitionWeaponTypeRepository definitionWeaponTypeRepository,
                                         DefinitionWeaponTypeBusinessRules definitionWeaponTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionWeaponTypeRepository = definitionWeaponTypeRepository;
            _definitionWeaponTypeBusinessRules = definitionWeaponTypeBusinessRules;
        }

        public async Task<UpdatedDefinitionWeaponTypeResponse> Handle(UpdateDefinitionWeaponTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionWeaponType? definitionWeaponType = await _definitionWeaponTypeRepository.GetAsync(predicate: dwt => dwt.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionWeaponTypeBusinessRules.DefinitionWeaponTypeShouldExistWhenSelected(definitionWeaponType);
            definitionWeaponType = _mapper.Map(request, definitionWeaponType);

            await _definitionWeaponTypeRepository.UpdateAsync(definitionWeaponType!);

            UpdatedDefinitionWeaponTypeResponse response = _mapper.Map<UpdatedDefinitionWeaponTypeResponse>(definitionWeaponType);
            return response;
        }
    }
}