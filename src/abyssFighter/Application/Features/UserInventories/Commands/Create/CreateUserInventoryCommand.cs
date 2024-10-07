using Application.Features.UserInventories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserInventories.Commands.Create;

public class CreateUserInventoryCommand : IRequest<CreatedUserInventoryResponse>
{
    public required Guid UserId { get; set; }
    public required Guid UserHeroId { get; set; }
    public required Guid DefinitionItemId { get; set; }
    public required Guid DefinitionItemTypeId { get; set; }
    public required decimal Amount { get; set; }

    public class CreateUserInventoryCommandHandler : IRequestHandler<CreateUserInventoryCommand, CreatedUserInventoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserInventoryRepository _userInventoryRepository;
        private readonly UserInventoryBusinessRules _userInventoryBusinessRules;

        public CreateUserInventoryCommandHandler(IMapper mapper, IUserInventoryRepository userInventoryRepository,
                                         UserInventoryBusinessRules userInventoryBusinessRules)
        {
            _mapper = mapper;
            _userInventoryRepository = userInventoryRepository;
            _userInventoryBusinessRules = userInventoryBusinessRules;
        }

        public async Task<CreatedUserInventoryResponse> Handle(CreateUserInventoryCommand request, CancellationToken cancellationToken)
        {
            UserInventory userInventory = _mapper.Map<UserInventory>(request);

            await _userInventoryRepository.AddAsync(userInventory);

            CreatedUserInventoryResponse response = _mapper.Map<CreatedUserInventoryResponse>(userInventory);
            return response;
        }
    }
}