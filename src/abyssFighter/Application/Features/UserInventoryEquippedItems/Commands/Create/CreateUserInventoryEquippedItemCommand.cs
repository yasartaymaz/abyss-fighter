using Application.Features.UserInventoryEquippedItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserInventoryEquippedItems.Commands.Create;

public class CreateUserInventoryEquippedItemCommand : IRequest<CreatedUserInventoryEquippedItemResponse>
{
    public required Guid UserId { get; set; }
    public required Guid UserHeroId { get; set; }
    public required Guid RightHand { get; set; }
    public required Guid LeftHand { get; set; }
    public required bool IsWeaponOneHanded { get; set; }
    public required Guid ArmorId { get; set; }
    public required Guid ConsumableSlot { get; set; }
    public required decimal Amount { get; set; }

    public class CreateUserInventoryEquippedItemCommandHandler : IRequestHandler<CreateUserInventoryEquippedItemCommand, CreatedUserInventoryEquippedItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserInventoryEquippedItemRepository _userInventoryEquippedItemRepository;
        private readonly UserInventoryEquippedItemBusinessRules _userInventoryEquippedItemBusinessRules;

        public CreateUserInventoryEquippedItemCommandHandler(IMapper mapper, IUserInventoryEquippedItemRepository userInventoryEquippedItemRepository,
                                         UserInventoryEquippedItemBusinessRules userInventoryEquippedItemBusinessRules)
        {
            _mapper = mapper;
            _userInventoryEquippedItemRepository = userInventoryEquippedItemRepository;
            _userInventoryEquippedItemBusinessRules = userInventoryEquippedItemBusinessRules;
        }

        public async Task<CreatedUserInventoryEquippedItemResponse> Handle(CreateUserInventoryEquippedItemCommand request, CancellationToken cancellationToken)
        {
            UserInventoryEquippedItem userInventoryEquippedItem = _mapper.Map<UserInventoryEquippedItem>(request);

            await _userInventoryEquippedItemRepository.AddAsync(userInventoryEquippedItem);

            CreatedUserInventoryEquippedItemResponse response = _mapper.Map<CreatedUserInventoryEquippedItemResponse>(userInventoryEquippedItem);
            return response;
        }
    }
}