using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserPets.Queries.GetList;

public class GetListUserPetQuery : IRequest<GetListResponse<GetListUserPetListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserPetQueryHandler : IRequestHandler<GetListUserPetQuery, GetListResponse<GetListUserPetListItemDto>>
    {
        private readonly IUserPetRepository _userPetRepository;
        private readonly IMapper _mapper;

        public GetListUserPetQueryHandler(IUserPetRepository userPetRepository, IMapper mapper)
        {
            _userPetRepository = userPetRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserPetListItemDto>> Handle(GetListUserPetQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserPet> userPets = await _userPetRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserPetListItemDto> response = _mapper.Map<GetListResponse<GetListUserPetListItemDto>>(userPets);
            return response;
        }
    }
}