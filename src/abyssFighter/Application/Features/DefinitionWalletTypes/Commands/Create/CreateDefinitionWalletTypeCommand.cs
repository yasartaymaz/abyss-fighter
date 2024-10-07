using Application.Features.DefinitionWalletTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWalletTypes.Commands.Create;

public class CreateDefinitionWalletTypeCommand : IRequest<CreatedDefinitionWalletTypeResponse>
{
    public string? Value { get; set; }

    public class CreateDefinitionWalletTypeCommandHandler : IRequestHandler<CreateDefinitionWalletTypeCommand, CreatedDefinitionWalletTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWalletTypeRepository _definitionWalletTypeRepository;
        private readonly DefinitionWalletTypeBusinessRules _definitionWalletTypeBusinessRules;

        public CreateDefinitionWalletTypeCommandHandler(IMapper mapper, IDefinitionWalletTypeRepository definitionWalletTypeRepository,
                                         DefinitionWalletTypeBusinessRules definitionWalletTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionWalletTypeRepository = definitionWalletTypeRepository;
            _definitionWalletTypeBusinessRules = definitionWalletTypeBusinessRules;
        }

        public async Task<CreatedDefinitionWalletTypeResponse> Handle(CreateDefinitionWalletTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionWalletType definitionWalletType = _mapper.Map<DefinitionWalletType>(request);

            await _definitionWalletTypeRepository.AddAsync(definitionWalletType);

            CreatedDefinitionWalletTypeResponse response = _mapper.Map<CreatedDefinitionWalletTypeResponse>(definitionWalletType);
            return response;
        }
    }
}