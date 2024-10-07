using Application.Features.DefinitionWeapons.Constants;
using Application.Features.DefinitionWeapons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWeapons.Commands.Delete;

public class DeleteDefinitionWeaponCommand : IRequest<DeletedDefinitionWeaponResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionWeaponCommandHandler : IRequestHandler<DeleteDefinitionWeaponCommand, DeletedDefinitionWeaponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWeaponRepository _definitionWeaponRepository;
        private readonly DefinitionWeaponBusinessRules _definitionWeaponBusinessRules;

        public DeleteDefinitionWeaponCommandHandler(IMapper mapper, IDefinitionWeaponRepository definitionWeaponRepository,
                                         DefinitionWeaponBusinessRules definitionWeaponBusinessRules)
        {
            _mapper = mapper;
            _definitionWeaponRepository = definitionWeaponRepository;
            _definitionWeaponBusinessRules = definitionWeaponBusinessRules;
        }

        public async Task<DeletedDefinitionWeaponResponse> Handle(DeleteDefinitionWeaponCommand request, CancellationToken cancellationToken)
        {
            DefinitionWeapon? definitionWeapon = await _definitionWeaponRepository.GetAsync(predicate: dw => dw.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionWeaponBusinessRules.DefinitionWeaponShouldExistWhenSelected(definitionWeapon);

            await _definitionWeaponRepository.DeleteAsync(definitionWeapon!);

            DeletedDefinitionWeaponResponse response = _mapper.Map<DeletedDefinitionWeaponResponse>(definitionWeapon);
            return response;
        }
    }
}