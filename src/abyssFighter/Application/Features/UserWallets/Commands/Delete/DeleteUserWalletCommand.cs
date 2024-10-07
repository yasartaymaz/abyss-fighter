using Application.Features.UserWallets.Constants;
using Application.Features.UserWallets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserWallets.Commands.Delete;

public class DeleteUserWalletCommand : IRequest<DeletedUserWalletResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserWalletCommandHandler : IRequestHandler<DeleteUserWalletCommand, DeletedUserWalletResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserWalletRepository _userWalletRepository;
        private readonly UserWalletBusinessRules _userWalletBusinessRules;

        public DeleteUserWalletCommandHandler(IMapper mapper, IUserWalletRepository userWalletRepository,
                                         UserWalletBusinessRules userWalletBusinessRules)
        {
            _mapper = mapper;
            _userWalletRepository = userWalletRepository;
            _userWalletBusinessRules = userWalletBusinessRules;
        }

        public async Task<DeletedUserWalletResponse> Handle(DeleteUserWalletCommand request, CancellationToken cancellationToken)
        {
            UserWallet? userWallet = await _userWalletRepository.GetAsync(predicate: uw => uw.Id == request.Id, cancellationToken: cancellationToken);
            await _userWalletBusinessRules.UserWalletShouldExistWhenSelected(userWallet);

            await _userWalletRepository.DeleteAsync(userWallet!);

            DeletedUserWalletResponse response = _mapper.Map<DeletedUserWalletResponse>(userWallet);
            return response;
        }
    }
}