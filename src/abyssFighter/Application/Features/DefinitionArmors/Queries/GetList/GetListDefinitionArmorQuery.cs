using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionArmors.Queries.GetList;

public class GetListDefinitionArmorQuery : IRequest<GetListResponse<GetListDefinitionArmorListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionArmorQueryHandler : IRequestHandler<GetListDefinitionArmorQuery, GetListResponse<GetListDefinitionArmorListItemDto>>
    {
        private readonly IDefinitionArmorRepository _definitionArmorRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionArmorQueryHandler(IDefinitionArmorRepository definitionArmorRepository, IMapper mapper)
        {
            _definitionArmorRepository = definitionArmorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionArmorListItemDto>> Handle(GetListDefinitionArmorQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionArmor> definitionArmors = await _definitionArmorRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionArmorListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionArmorListItemDto>>(definitionArmors);
            return response;
        }
    }
}