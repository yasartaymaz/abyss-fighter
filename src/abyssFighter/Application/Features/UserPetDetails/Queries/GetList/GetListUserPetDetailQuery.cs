using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserPetDetails.Queries.GetList;

public class GetListUserPetDetailQuery : IRequest<GetListResponse<GetListUserPetDetailListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserPetDetailQueryHandler : IRequestHandler<GetListUserPetDetailQuery, GetListResponse<GetListUserPetDetailListItemDto>>
    {
        private readonly IUserPetDetailRepository _userPetDetailRepository;
        private readonly IMapper _mapper;

        public GetListUserPetDetailQueryHandler(IUserPetDetailRepository userPetDetailRepository, IMapper mapper)
        {
            _userPetDetailRepository = userPetDetailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserPetDetailListItemDto>> Handle(GetListUserPetDetailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserPetDetail> userPetDetails = await _userPetDetailRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserPetDetailListItemDto> response = _mapper.Map<GetListResponse<GetListUserPetDetailListItemDto>>(userPetDetails);
            return response;
        }
    }
}