using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserInventoryEquippedItems.Queries.GetList;

public class GetListUserInventoryEquippedItemQuery : IRequest<GetListResponse<GetListUserInventoryEquippedItemListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserInventoryEquippedItemQueryHandler : IRequestHandler<GetListUserInventoryEquippedItemQuery, GetListResponse<GetListUserInventoryEquippedItemListItemDto>>
    {
        private readonly IUserInventoryEquippedItemRepository _userInventoryEquippedItemRepository;
        private readonly IMapper _mapper;

        public GetListUserInventoryEquippedItemQueryHandler(IUserInventoryEquippedItemRepository userInventoryEquippedItemRepository, IMapper mapper)
        {
            _userInventoryEquippedItemRepository = userInventoryEquippedItemRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserInventoryEquippedItemListItemDto>> Handle(GetListUserInventoryEquippedItemQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserInventoryEquippedItem> userInventoryEquippedItems = await _userInventoryEquippedItemRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserInventoryEquippedItemListItemDto> response = _mapper.Map<GetListResponse<GetListUserInventoryEquippedItemListItemDto>>(userInventoryEquippedItems);
            return response;
        }
    }
}