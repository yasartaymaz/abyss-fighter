using Application.Features.UserPets.Constants;
using Application.Features.UserPets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserPets.Commands.Delete;

public class DeleteUserPetCommand : IRequest<DeletedUserPetResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserPetCommandHandler : IRequestHandler<DeleteUserPetCommand, DeletedUserPetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPetRepository _userPetRepository;
        private readonly UserPetBusinessRules _userPetBusinessRules;

        public DeleteUserPetCommandHandler(IMapper mapper, IUserPetRepository userPetRepository,
                                         UserPetBusinessRules userPetBusinessRules)
        {
            _mapper = mapper;
            _userPetRepository = userPetRepository;
            _userPetBusinessRules = userPetBusinessRules;
        }

        public async Task<DeletedUserPetResponse> Handle(DeleteUserPetCommand request, CancellationToken cancellationToken)
        {
            UserPet? userPet = await _userPetRepository.GetAsync(predicate: up => up.Id == request.Id, cancellationToken: cancellationToken);
            await _userPetBusinessRules.UserPetShouldExistWhenSelected(userPet);

            await _userPetRepository.DeleteAsync(userPet!);

            DeletedUserPetResponse response = _mapper.Map<DeletedUserPetResponse>(userPet);
            return response;
        }
    }
}