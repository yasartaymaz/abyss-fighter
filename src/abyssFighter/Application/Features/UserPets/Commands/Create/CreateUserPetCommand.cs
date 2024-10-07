using Application.Features.UserPets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserPets.Commands.Create;

public class CreateUserPetCommand : IRequest<CreatedUserPetResponse>
{
    public required Guid UserId { get; set; }
    public required Guid DefinitionPetId { get; set; }
    public required decimal HealthPoints { get; set; }
    public required decimal AttackPoints { get; set; }
    public required decimal DefencePoints { get; set; }

    public class CreateUserPetCommandHandler : IRequestHandler<CreateUserPetCommand, CreatedUserPetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPetRepository _userPetRepository;
        private readonly UserPetBusinessRules _userPetBusinessRules;

        public CreateUserPetCommandHandler(IMapper mapper, IUserPetRepository userPetRepository,
                                         UserPetBusinessRules userPetBusinessRules)
        {
            _mapper = mapper;
            _userPetRepository = userPetRepository;
            _userPetBusinessRules = userPetBusinessRules;
        }

        public async Task<CreatedUserPetResponse> Handle(CreateUserPetCommand request, CancellationToken cancellationToken)
        {
            UserPet userPet = _mapper.Map<UserPet>(request);

            await _userPetRepository.AddAsync(userPet);

            CreatedUserPetResponse response = _mapper.Map<CreatedUserPetResponse>(userPet);
            return response;
        }
    }
}