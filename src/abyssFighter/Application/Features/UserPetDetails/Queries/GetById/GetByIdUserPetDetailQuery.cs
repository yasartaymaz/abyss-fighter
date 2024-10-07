using Application.Features.UserPetDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserPetDetails.Queries.GetById;

public class GetByIdUserPetDetailQuery : IRequest<GetByIdUserPetDetailResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUserPetDetailQueryHandler : IRequestHandler<GetByIdUserPetDetailQuery, GetByIdUserPetDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPetDetailRepository _userPetDetailRepository;
        private readonly UserPetDetailBusinessRules _userPetDetailBusinessRules;

        public GetByIdUserPetDetailQueryHandler(IMapper mapper, IUserPetDetailRepository userPetDetailRepository, UserPetDetailBusinessRules userPetDetailBusinessRules)
        {
            _mapper = mapper;
            _userPetDetailRepository = userPetDetailRepository;
            _userPetDetailBusinessRules = userPetDetailBusinessRules;
        }

        public async Task<GetByIdUserPetDetailResponse> Handle(GetByIdUserPetDetailQuery request, CancellationToken cancellationToken)
        {
            UserPetDetail? userPetDetail = await _userPetDetailRepository.GetAsync(predicate: upd => upd.Id == request.Id, cancellationToken: cancellationToken);
            await _userPetDetailBusinessRules.UserPetDetailShouldExistWhenSelected(userPetDetail);

            GetByIdUserPetDetailResponse response = _mapper.Map<GetByIdUserPetDetailResponse>(userPetDetail);
            return response;
        }
    }
}