using Application.Features.DefinitionWalletTypes.Constants;
using Application.Features.DefinitionWalletTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWalletTypes.Commands.Delete;

public class DeleteDefinitionWalletTypeCommand : IRequest<DeletedDefinitionWalletTypeResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionWalletTypeCommandHandler : IRequestHandler<DeleteDefinitionWalletTypeCommand, DeletedDefinitionWalletTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWalletTypeRepository _definitionWalletTypeRepository;
        private readonly DefinitionWalletTypeBusinessRules _definitionWalletTypeBusinessRules;

        public DeleteDefinitionWalletTypeCommandHandler(IMapper mapper, IDefinitionWalletTypeRepository definitionWalletTypeRepository,
                                         DefinitionWalletTypeBusinessRules definitionWalletTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionWalletTypeRepository = definitionWalletTypeRepository;
            _definitionWalletTypeBusinessRules = definitionWalletTypeBusinessRules;
        }

        public async Task<DeletedDefinitionWalletTypeResponse> Handle(DeleteDefinitionWalletTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionWalletType? definitionWalletType = await _definitionWalletTypeRepository.GetAsync(predicate: dwt => dwt.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionWalletTypeBusinessRules.DefinitionWalletTypeShouldExistWhenSelected(definitionWalletType);

            await _definitionWalletTypeRepository.DeleteAsync(definitionWalletType!);

            DeletedDefinitionWalletTypeResponse response = _mapper.Map<DeletedDefinitionWalletTypeResponse>(definitionWalletType);
            return response;
        }
    }
}