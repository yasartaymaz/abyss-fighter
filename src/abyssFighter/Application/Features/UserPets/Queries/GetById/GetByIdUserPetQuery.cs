using Application.Features.UserPets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserPets.Queries.GetById;

public class GetByIdUserPetQuery : IRequest<GetByIdUserPetResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUserPetQueryHandler : IRequestHandler<GetByIdUserPetQuery, GetByIdUserPetResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPetRepository _userPetRepository;
        private readonly UserPetBusinessRules _userPetBusinessRules;

        public GetByIdUserPetQueryHandler(IMapper mapper, IUserPetRepository userPetRepository, UserPetBusinessRules userPetBusinessRules)
        {
            _mapper = mapper;
            _userPetRepository = userPetRepository;
            _userPetBusinessRules = userPetBusinessRules;
        }

        public async Task<GetByIdUserPetResponse> Handle(GetByIdUserPetQuery request, CancellationToken cancellationToken)
        {
            UserPet? userPet = await _userPetRepository.GetAsync(predicate: up => up.Id == request.Id, cancellationToken: cancellationToken);
            await _userPetBusinessRules.UserPetShouldExistWhenSelected(userPet);

            GetByIdUserPetResponse response = _mapper.Map<GetByIdUserPetResponse>(userPet);
            return response;
        }
    }
}