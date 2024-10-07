using Application.Features.UserHeroes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserHeroes.Commands.Create;

public class CreateUserHeroCommand : IRequest<CreatedUserHeroResponse>
{
    public required Guid UserId { get; set; }
    public string? Name { get; set; }
    public required Guid DefinitionHeroClassId { get; set; }

    public class CreateUserHeroCommandHandler : IRequestHandler<CreateUserHeroCommand, CreatedUserHeroResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserHeroRepository _userHeroRepository;
        private readonly UserHeroBusinessRules _userHeroBusinessRules;

        public CreateUserHeroCommandHandler(IMapper mapper, IUserHeroRepository userHeroRepository,
                                         UserHeroBusinessRules userHeroBusinessRules)
        {
            _mapper = mapper;
            _userHeroRepository = userHeroRepository;
            _userHeroBusinessRules = userHeroBusinessRules;
        }

        public async Task<CreatedUserHeroResponse> Handle(CreateUserHeroCommand request, CancellationToken cancellationToken)
        {
            UserHero userHero = _mapper.Map<UserHero>(request);

            await _userHeroRepository.AddAsync(userHero);

            CreatedUserHeroResponse response = _mapper.Map<CreatedUserHeroResponse>(userHero);
            return response;
        }
    }
}