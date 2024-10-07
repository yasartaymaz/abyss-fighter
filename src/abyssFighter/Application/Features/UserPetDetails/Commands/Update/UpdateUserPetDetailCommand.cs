using Application.Features.UserPetDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserPetDetails.Commands.Update;

public class UpdateUserPetDetailCommand : IRequest<UpdatedUserPetDetailResponse>
{
    public Guid Id { get; set; }
    public required Guid UserPetId { get; set; }
    public required decimal AttackPoints { get; set; }
    public required decimal DefencePoints { get; set; }

    public class UpdateUserPetDetailCommandHandler : IRequestHandler<UpdateUserPetDetailCommand, UpdatedUserPetDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPetDetailRepository _userPetDetailRepository;
        private readonly UserPetDetailBusinessRules _userPetDetailBusinessRules;

        public UpdateUserPetDetailCommandHandler(IMapper mapper, IUserPetDetailRepository userPetDetailRepository,
                                         UserPetDetailBusinessRules userPetDetailBusinessRules)
        {
            _mapper = mapper;
            _userPetDetailRepository = userPetDetailRepository;
            _userPetDetailBusinessRules = userPetDetailBusinessRules;
        }

        public async Task<UpdatedUserPetDetailResponse> Handle(UpdateUserPetDetailCommand request, CancellationToken cancellationToken)
        {
            UserPetDetail? userPetDetail = await _userPetDetailRepository.GetAsync(predicate: upd => upd.Id == request.Id, cancellationToken: cancellationToken);
            await _userPetDetailBusinessRules.UserPetDetailShouldExistWhenSelected(userPetDetail);
            userPetDetail = _mapper.Map(request, userPetDetail);

            await _userPetDetailRepository.UpdateAsync(userPetDetail!);

            UpdatedUserPetDetailResponse response = _mapper.Map<UpdatedUserPetDetailResponse>(userPetDetail);
            return response;
        }
    }
}