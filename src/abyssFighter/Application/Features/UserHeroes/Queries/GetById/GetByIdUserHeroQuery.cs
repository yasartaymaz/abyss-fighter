using Application.Features.UserHeroes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserHeroes.Queries.GetById;

public class GetByIdUserHeroQuery : IRequest<GetByIdUserHeroResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUserHeroQueryHandler : IRequestHandler<GetByIdUserHeroQuery, GetByIdUserHeroResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserHeroRepository _userHeroRepository;
        private readonly UserHeroBusinessRules _userHeroBusinessRules;

        public GetByIdUserHeroQueryHandler(IMapper mapper, IUserHeroRepository userHeroRepository, UserHeroBusinessRules userHeroBusinessRules)
        {
            _mapper = mapper;
            _userHeroRepository = userHeroRepository;
            _userHeroBusinessRules = userHeroBusinessRules;
        }

        public async Task<GetByIdUserHeroResponse> Handle(GetByIdUserHeroQuery request, CancellationToken cancellationToken)
        {
            UserHero? userHero = await _userHeroRepository.GetAsync(predicate: uh => uh.Id == request.Id, cancellationToken: cancellationToken);
            await _userHeroBusinessRules.UserHeroShouldExistWhenSelected(userHero);

            GetByIdUserHeroResponse response = _mapper.Map<GetByIdUserHeroResponse>(userHero);
            return response;
        }
    }
}