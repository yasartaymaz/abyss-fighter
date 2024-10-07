using Application.Features.DefinitionWalletTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWalletTypes.Commands.Update;

public class UpdateDefinitionWalletTypeCommand : IRequest<UpdatedDefinitionWalletTypeResponse>
{
    public Guid Id { get; set; }
    public string? Value { get; set; }

    public class UpdateDefinitionWalletTypeCommandHandler : IRequestHandler<UpdateDefinitionWalletTypeCommand, UpdatedDefinitionWalletTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWalletTypeRepository _definitionWalletTypeRepository;
        private readonly DefinitionWalletTypeBusinessRules _definitionWalletTypeBusinessRules;

        public UpdateDefinitionWalletTypeCommandHandler(IMapper mapper, IDefinitionWalletTypeRepository definitionWalletTypeRepository,
                                         DefinitionWalletTypeBusinessRules definitionWalletTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionWalletTypeRepository = definitionWalletTypeRepository;
            _definitionWalletTypeBusinessRules = definitionWalletTypeBusinessRules;
        }

        public async Task<UpdatedDefinitionWalletTypeResponse> Handle(UpdateDefinitionWalletTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionWalletType? definitionWalletType = await _definitionWalletTypeRepository.GetAsync(predicate: dwt => dwt.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionWalletTypeBusinessRules.DefinitionWalletTypeShouldExistWhenSelected(definitionWalletType);
            definitionWalletType = _mapper.Map(request, definitionWalletType);

            await _definitionWalletTypeRepository.UpdateAsync(definitionWalletType!);

            UpdatedDefinitionWalletTypeResponse response = _mapper.Map<UpdatedDefinitionWalletTypeResponse>(definitionWalletType);
            return response;
        }
    }
}