using Application.Features.UserWallets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserWallets.Queries.GetById;

public class GetByIdUserWalletQuery : IRequest<GetByIdUserWalletResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUserWalletQueryHandler : IRequestHandler<GetByIdUserWalletQuery, GetByIdUserWalletResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserWalletRepository _userWalletRepository;
        private readonly UserWalletBusinessRules _userWalletBusinessRules;

        public GetByIdUserWalletQueryHandler(IMapper mapper, IUserWalletRepository userWalletRepository, UserWalletBusinessRules userWalletBusinessRules)
        {
            _mapper = mapper;
            _userWalletRepository = userWalletRepository;
            _userWalletBusinessRules = userWalletBusinessRules;
        }

        public async Task<GetByIdUserWalletResponse> Handle(GetByIdUserWalletQuery request, CancellationToken cancellationToken)
        {
            UserWallet? userWallet = await _userWalletRepository.GetAsync(predicate: uw => uw.Id == request.Id, cancellationToken: cancellationToken);
            await _userWalletBusinessRules.UserWalletShouldExistWhenSelected(userWallet);

            GetByIdUserWalletResponse response = _mapper.Map<GetByIdUserWalletResponse>(userWallet);
            return response;
        }
    }
}