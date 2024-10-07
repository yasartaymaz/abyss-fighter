using Application.Features.UserWallets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserWallets.Commands.Create;

public class CreateUserWalletCommand : IRequest<CreatedUserWalletResponse>
{
    public required Guid UserId { get; set; }
    public required Guid DefinitionWalletTypeId { get; set; }
    public string? WalletAddress { get; set; }

    public class CreateUserWalletCommandHandler : IRequestHandler<CreateUserWalletCommand, CreatedUserWalletResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserWalletRepository _userWalletRepository;
        private readonly UserWalletBusinessRules _userWalletBusinessRules;

        public CreateUserWalletCommandHandler(IMapper mapper, IUserWalletRepository userWalletRepository,
                                         UserWalletBusinessRules userWalletBusinessRules)
        {
            _mapper = mapper;
            _userWalletRepository = userWalletRepository;
            _userWalletBusinessRules = userWalletBusinessRules;
        }

        public async Task<CreatedUserWalletResponse> Handle(CreateUserWalletCommand request, CancellationToken cancellationToken)
        {
            UserWallet userWallet = _mapper.Map<UserWallet>(request);

            await _userWalletRepository.AddAsync(userWallet);

            CreatedUserWalletResponse response = _mapper.Map<CreatedUserWalletResponse>(userWallet);
            return response;
        }
    }
}