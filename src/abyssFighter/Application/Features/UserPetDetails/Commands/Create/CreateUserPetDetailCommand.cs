using Application.Features.UserPetDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserPetDetails.Commands.Create;

public class CreateUserPetDetailCommand : IRequest<CreatedUserPetDetailResponse>
{
    public required Guid UserPetId { get; set; }
    public required decimal AttackPoints { get; set; }
    public required decimal DefencePoints { get; set; }

    public class CreateUserPetDetailCommandHandler : IRequestHandler<CreateUserPetDetailCommand, CreatedUserPetDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPetDetailRepository _userPetDetailRepository;
        private readonly UserPetDetailBusinessRules _userPetDetailBusinessRules;

        public CreateUserPetDetailCommandHandler(IMapper mapper, IUserPetDetailRepository userPetDetailRepository,
                                         UserPetDetailBusinessRules userPetDetailBusinessRules)
        {
            _mapper = mapper;
            _userPetDetailRepository = userPetDetailRepository;
            _userPetDetailBusinessRules = userPetDetailBusinessRules;
        }

        public async Task<CreatedUserPetDetailResponse> Handle(CreateUserPetDetailCommand request, CancellationToken cancellationToken)
        {
            UserPetDetail userPetDetail = _mapper.Map<UserPetDetail>(request);

            await _userPetDetailRepository.AddAsync(userPetDetail);

            CreatedUserPetDetailResponse response = _mapper.Map<CreatedUserPetDetailResponse>(userPetDetail);
            return response;
        }
    }
}