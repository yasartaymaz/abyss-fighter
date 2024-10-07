using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionItems.Queries.GetList;

public class GetListDefinitionItemQuery : IRequest<GetListResponse<GetListDefinitionItemListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionItemQueryHandler : IRequestHandler<GetListDefinitionItemQuery, GetListResponse<GetListDefinitionItemListItemDto>>
    {
        private readonly IDefinitionItemRepository _definitionItemRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionItemQueryHandler(IDefinitionItemRepository definitionItemRepository, IMapper mapper)
        {
            _definitionItemRepository = definitionItemRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionItemListItemDto>> Handle(GetListDefinitionItemQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionItem> definitionItems = await _definitionItemRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionItemListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionItemListItemDto>>(definitionItems);
            return response;
        }
    }
}