using Application.Features.DefinitionWeaponTypes.Constants;
using Application.Features.DefinitionWeaponTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWeaponTypes.Commands.Delete;

public class DeleteDefinitionWeaponTypeCommand : IRequest<DeletedDefinitionWeaponTypeResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionWeaponTypeCommandHandler : IRequestHandler<DeleteDefinitionWeaponTypeCommand, DeletedDefinitionWeaponTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWeaponTypeRepository _definitionWeaponTypeRepository;
        private readonly DefinitionWeaponTypeBusinessRules _definitionWeaponTypeBusinessRules;

        public DeleteDefinitionWeaponTypeCommandHandler(IMapper mapper, IDefinitionWeaponTypeRepository definitionWeaponTypeRepository,
                                         DefinitionWeaponTypeBusinessRules definitionWeaponTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionWeaponTypeRepository = definitionWeaponTypeRepository;
            _definitionWeaponTypeBusinessRules = definitionWeaponTypeBusinessRules;
        }

        public async Task<DeletedDefinitionWeaponTypeResponse> Handle(DeleteDefinitionWeaponTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionWeaponType? definitionWeaponType = await _definitionWeaponTypeRepository.GetAsync(predicate: dwt => dwt.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionWeaponTypeBusinessRules.DefinitionWeaponTypeShouldExistWhenSelected(definitionWeaponType);

            await _definitionWeaponTypeRepository.DeleteAsync(definitionWeaponType!);

            DeletedDefinitionWeaponTypeResponse response = _mapper.Map<DeletedDefinitionWeaponTypeResponse>(definitionWeaponType);
            return response;
        }
    }
}