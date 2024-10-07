using Application.Features.UserPetDetails.Constants;
using Application.Features.UserPetDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserPetDetails.Commands.Delete;

public class DeleteUserPetDetailCommand : IRequest<DeletedUserPetDetailResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserPetDetailCommandHandler : IRequestHandler<DeleteUserPetDetailCommand, DeletedUserPetDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPetDetailRepository _userPetDetailRepository;
        private readonly UserPetDetailBusinessRules _userPetDetailBusinessRules;

        public DeleteUserPetDetailCommandHandler(IMapper mapper, IUserPetDetailRepository userPetDetailRepository,
                                         UserPetDetailBusinessRules userPetDetailBusinessRules)
        {
            _mapper = mapper;
            _userPetDetailRepository = userPetDetailRepository;
            _userPetDetailBusinessRules = userPetDetailBusinessRules;
        }

        public async Task<DeletedUserPetDetailResponse> Handle(DeleteUserPetDetailCommand request, CancellationToken cancellationToken)
        {
            UserPetDetail? userPetDetail = await _userPetDetailRepository.GetAsync(predicate: upd => upd.Id == request.Id, cancellationToken: cancellationToken);
            await _userPetDetailBusinessRules.UserPetDetailShouldExistWhenSelected(userPetDetail);

            await _userPetDetailRepository.DeleteAsync(userPetDetail!);

            DeletedUserPetDetailResponse response = _mapper.Map<DeletedUserPetDetailResponse>(userPetDetail);
            return response;
        }
    }
}