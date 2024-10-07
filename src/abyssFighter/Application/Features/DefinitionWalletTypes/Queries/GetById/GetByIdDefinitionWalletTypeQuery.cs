using Application.Features.DefinitionWalletTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWalletTypes.Queries.GetById;

public class GetByIdDefinitionWalletTypeQuery : IRequest<GetByIdDefinitionWalletTypeResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionWalletTypeQueryHandler : IRequestHandler<GetByIdDefinitionWalletTypeQuery, GetByIdDefinitionWalletTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWalletTypeRepository _definitionWalletTypeRepository;
        private readonly DefinitionWalletTypeBusinessRules _definitionWalletTypeBusinessRules;

        public GetByIdDefinitionWalletTypeQueryHandler(IMapper mapper, IDefinitionWalletTypeRepository definitionWalletTypeRepository, DefinitionWalletTypeBusinessRules definitionWalletTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionWalletTypeRepository = definitionWalletTypeRepository;
            _definitionWalletTypeBusinessRules = definitionWalletTypeBusinessRules;
        }

        public async Task<GetByIdDefinitionWalletTypeResponse> Handle(GetByIdDefinitionWalletTypeQuery request, CancellationToken cancellationToken)
        {
            DefinitionWalletType? definitionWalletType = await _definitionWalletTypeRepository.GetAsync(predicate: dwt => dwt.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionWalletTypeBusinessRules.DefinitionWalletTypeShouldExistWhenSelected(definitionWalletType);

            GetByIdDefinitionWalletTypeResponse response = _mapper.Map<GetByIdDefinitionWalletTypeResponse>(definitionWalletType);
            return response;
        }
    }
}