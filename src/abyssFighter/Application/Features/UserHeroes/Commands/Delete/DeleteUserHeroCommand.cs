using Application.Features.UserHeroes.Constants;
using Application.Features.UserHeroes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserHeroes.Commands.Delete;

public class DeleteUserHeroCommand : IRequest<DeletedUserHeroResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserHeroCommandHandler : IRequestHandler<DeleteUserHeroCommand, DeletedUserHeroResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserHeroRepository _userHeroRepository;
        private readonly UserHeroBusinessRules _userHeroBusinessRules;

        public DeleteUserHeroCommandHandler(IMapper mapper, IUserHeroRepository userHeroRepository,
                                         UserHeroBusinessRules userHeroBusinessRules)
        {
            _mapper = mapper;
            _userHeroRepository = userHeroRepository;
            _userHeroBusinessRules = userHeroBusinessRules;
        }

        public async Task<DeletedUserHeroResponse> Handle(DeleteUserHeroCommand request, CancellationToken cancellationToken)
        {
            UserHero? userHero = await _userHeroRepository.GetAsync(predicate: uh => uh.Id == request.Id, cancellationToken: cancellationToken);
            await _userHeroBusinessRules.UserHeroShouldExistWhenSelected(userHero);

            await _userHeroRepository.DeleteAsync(userHero!);

            DeletedUserHeroResponse response = _mapper.Map<DeletedUserHeroResponse>(userHero);
            return response;
        }
    }
}