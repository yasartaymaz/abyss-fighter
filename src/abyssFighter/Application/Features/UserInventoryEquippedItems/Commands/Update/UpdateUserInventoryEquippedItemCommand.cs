using Application.Features.UserInventoryEquippedItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserInventoryEquippedItems.Commands.Update;

public class UpdateUserInventoryEquippedItemCommand : IRequest<UpdatedUserInventoryEquippedItemResponse>
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required Guid UserHeroId { get; set; }
    public required Guid RightHand { get; set; }
    public required Guid LeftHand { get; set; }
    public required bool IsWeaponOneHanded { get; set; }
    public required Guid ArmorId { get; set; }
    public required Guid ConsumableSlot { get; set; }
    public required decimal Amount { get; set; }

    public class UpdateUserInventoryEquippedItemCommandHandler : IRequestHandler<UpdateUserInventoryEquippedItemCommand, UpdatedUserInventoryEquippedItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserInventoryEquippedItemRepository _userInventoryEquippedItemRepository;
        private readonly UserInventoryEquippedItemBusinessRules _userInventoryEquippedItemBusinessRules;

        public UpdateUserInventoryEquippedItemCommandHandler(IMapper mapper, IUserInventoryEquippedItemRepository userInventoryEquippedItemRepository,
                                         UserInventoryEquippedItemBusinessRules userInventoryEquippedItemBusinessRules)
        {
            _mapper = mapper;
            _userInventoryEquippedItemRepository = userInventoryEquippedItemRepository;
            _userInventoryEquippedItemBusinessRules = userInventoryEquippedItemBusinessRules;
        }

        public async Task<UpdatedUserInventoryEquippedItemResponse> Handle(UpdateUserInventoryEquippedItemCommand request, CancellationToken cancellationToken)
        {
            UserInventoryEquippedItem? userInventoryEquippedItem = await _userInventoryEquippedItemRepository.GetAsync(predicate: uiei => uiei.Id == request.Id, cancellationToken: cancellationToken);
            await _userInventoryEquippedItemBusinessRules.UserInventoryEquippedItemShouldExistWhenSelected(userInventoryEquippedItem);
            userInventoryEquippedItem = _mapper.Map(request, userInventoryEquippedItem);

            await _userInventoryEquippedItemRepository.UpdateAsync(userInventoryEquippedItem!);

            UpdatedUserInventoryEquippedItemResponse response = _mapper.Map<UpdatedUserInventoryEquippedItemResponse>(userInventoryEquippedItem);
            return response;
        }
    }
}