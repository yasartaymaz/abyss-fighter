using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserWallets.Queries.GetList;

public class GetListUserWalletQuery : IRequest<GetListResponse<GetListUserWalletListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserWalletQueryHandler : IRequestHandler<GetListUserWalletQuery, GetListResponse<GetListUserWalletListItemDto>>
    {
        private readonly IUserWalletRepository _userWalletRepository;
        private readonly IMapper _mapper;

        public GetListUserWalletQueryHandler(IUserWalletRepository userWalletRepository, IMapper mapper)
        {
            _userWalletRepository = userWalletRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserWalletListItemDto>> Handle(GetListUserWalletQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserWallet> userWallets = await _userWalletRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserWalletListItemDto> response = _mapper.Map<GetListResponse<GetListUserWalletListItemDto>>(userWallets);
            return response;
        }
    }
}