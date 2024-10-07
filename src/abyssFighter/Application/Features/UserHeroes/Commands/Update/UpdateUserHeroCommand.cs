using Application.Features.UserHeroes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserHeroes.Commands.Update;

public class UpdateUserHeroCommand : IRequest<UpdatedUserHeroResponse>
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public string? Name { get; set; }
    public required Guid DefinitionHeroClassId { get; set; }

    public class UpdateUserHeroCommandHandler : IRequestHandler<UpdateUserHeroCommand, UpdatedUserHeroResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserHeroRepository _userHeroRepository;
        private readonly UserHeroBusinessRules _userHeroBusinessRules;

        public UpdateUserHeroCommandHandler(IMapper mapper, IUserHeroRepository userHeroRepository,
                                         UserHeroBusinessRules userHeroBusinessRules)
        {
            _mapper = mapper;
            _userHeroRepository = userHeroRepository;
            _userHeroBusinessRules = userHeroBusinessRules;
        }

        public async Task<UpdatedUserHeroResponse> Handle(UpdateUserHeroCommand request, CancellationToken cancellationToken)
        {
            UserHero? userHero = await _userHeroRepository.GetAsync(predicate: uh => uh.Id == request.Id, cancellationToken: cancellationToken);
            await _userHeroBusinessRules.UserHeroShouldExistWhenSelected(userHero);
            userHero = _mapper.Map(request, userHero);

            await _userHeroRepository.UpdateAsync(userHero!);

            UpdatedUserHeroResponse response = _mapper.Map<UpdatedUserHeroResponse>(userHero);
            return response;
        }
    }
}