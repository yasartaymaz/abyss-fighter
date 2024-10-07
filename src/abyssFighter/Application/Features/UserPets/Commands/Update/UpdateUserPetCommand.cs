using Application.Features.UserPets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserPets.Commands.Update;

public class UpdateUserPetCommand : IRequest<UpdatedUserPetResponse>
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required Guid DefinitionPetId { get; set; }
    public required decimal HealthPoints { get; set; }
    public required decimal AttackPoints { get; set; }
    public required decimal DefencePoints { get; set; }

    public class UpdateUserPetCommandHandler : IRequestHandler<UpdateUserPetCommand, UpdatedUserPetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPetRepository _userPetRepository;
        private readonly UserPetBusinessRules _userPetBusinessRules;

        public UpdateUserPetCommandHandler(IMapper mapper, IUserPetRepository userPetRepository,
                                         UserPetBusinessRules userPetBusinessRules)
        {
            _mapper = mapper;
            _userPetRepository = userPetRepository;
            _userPetBusinessRules = userPetBusinessRules;
        }

        public async Task<UpdatedUserPetResponse> Handle(UpdateUserPetCommand request, CancellationToken cancellationToken)
        {
            UserPet? userPet = await _userPetRepository.GetAsync(predicate: up => up.Id == request.Id, cancellationToken: cancellationToken);
            await _userPetBusinessRules.UserPetShouldExistWhenSelected(userPet);
            userPet = _mapper.Map(request, userPet);

            await _userPetRepository.UpdateAsync(userPet!);

            UpdatedUserPetResponse response = _mapper.Map<UpdatedUserPetResponse>(userPet);
            return response;
        }
    }
}