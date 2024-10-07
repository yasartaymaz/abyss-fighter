using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserInventories.Queries.GetList;

public class GetListUserInventoryQuery : IRequest<GetListResponse<GetListUserInventoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserInventoryQueryHandler : IRequestHandler<GetListUserInventoryQuery, GetListResponse<GetListUserInventoryListItemDto>>
    {
        private readonly IUserInventoryRepository _userInventoryRepository;
        private readonly IMapper _mapper;

        public GetListUserInventoryQueryHandler(IUserInventoryRepository userInventoryRepository, IMapper mapper)
        {
            _userInventoryRepository = userInventoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserInventoryListItemDto>> Handle(GetListUserInventoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserInventory> userInventories = await _userInventoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserInventoryListItemDto> response = _mapper.Map<GetListResponse<GetListUserInventoryListItemDto>>(userInventories);
            return response;
        }
    }
}