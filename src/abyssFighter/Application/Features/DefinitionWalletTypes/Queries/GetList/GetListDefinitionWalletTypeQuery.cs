using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionWalletTypes.Queries.GetList;

public class GetListDefinitionWalletTypeQuery : IRequest<GetListResponse<GetListDefinitionWalletTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionWalletTypeQueryHandler : IRequestHandler<GetListDefinitionWalletTypeQuery, GetListResponse<GetListDefinitionWalletTypeListItemDto>>
    {
        private readonly IDefinitionWalletTypeRepository _definitionWalletTypeRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionWalletTypeQueryHandler(IDefinitionWalletTypeRepository definitionWalletTypeRepository, IMapper mapper)
        {
            _definitionWalletTypeRepository = definitionWalletTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionWalletTypeListItemDto>> Handle(GetListDefinitionWalletTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionWalletType> definitionWalletTypes = await _definitionWalletTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionWalletTypeListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionWalletTypeListItemDto>>(definitionWalletTypes);
            return response;
        }
    }
}