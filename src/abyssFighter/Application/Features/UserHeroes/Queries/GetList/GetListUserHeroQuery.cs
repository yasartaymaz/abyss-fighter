using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserHeroes.Queries.GetList;

public class GetListUserHeroQuery : IRequest<GetListResponse<GetListUserHeroListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserHeroQueryHandler : IRequestHandler<GetListUserHeroQuery, GetListResponse<GetListUserHeroListItemDto>>
    {
        private readonly IUserHeroRepository _userHeroRepository;
        private readonly IMapper _mapper;

        public GetListUserHeroQueryHandler(IUserHeroRepository userHeroRepository, IMapper mapper)
        {
            _userHeroRepository = userHeroRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserHeroListItemDto>> Handle(GetListUserHeroQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserHero> userHeroes = await _userHeroRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserHeroListItemDto> response = _mapper.Map<GetListResponse<GetListUserHeroListItemDto>>(userHeroes);
            return response;
        }
    }
}