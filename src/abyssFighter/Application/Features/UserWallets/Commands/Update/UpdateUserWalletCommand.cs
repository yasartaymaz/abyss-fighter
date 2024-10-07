using Application.Features.UserWallets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserWallets.Commands.Update;

public class UpdateUserWalletCommand : IRequest<UpdatedUserWalletResponse>
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required Guid DefinitionWalletTypeId { get; set; }
    public string? WalletAddress { get; set; }

    public class UpdateUserWalletCommandHandler : IRequestHandler<UpdateUserWalletCommand, UpdatedUserWalletResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserWalletRepository _userWalletRepository;
        private readonly UserWalletBusinessRules _userWalletBusinessRules;

        public UpdateUserWalletCommandHandler(IMapper mapper, IUserWalletRepository userWalletRepository,
                                         UserWalletBusinessRules userWalletBusinessRules)
        {
            _mapper = mapper;
            _userWalletRepository = userWalletRepository;
            _userWalletBusinessRules = userWalletBusinessRules;
        }

        public async Task<UpdatedUserWalletResponse> Handle(UpdateUserWalletCommand request, CancellationToken cancellationToken)
        {
            UserWallet? userWallet = await _userWalletRepository.GetAsync(predicate: uw => uw.Id == request.Id, cancellationToken: cancellationToken);
            await _userWalletBusinessRules.UserWalletShouldExistWhenSelected(userWallet);
            userWallet = _mapper.Map(request, userWallet);

            await _userWalletRepository.UpdateAsync(userWallet!);

            UpdatedUserWalletResponse response = _mapper.Map<UpdatedUserWalletResponse>(userWallet);
            return response;
        }
    }
}