using Application.Features.UserInventoryEquippedItems.Constants;
using Application.Features.UserInventoryEquippedItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserInventoryEquippedItems.Commands.Delete;

public class DeleteUserInventoryEquippedItemCommand : IRequest<DeletedUserInventoryEquippedItemResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserInventoryEquippedItemCommandHandler : IRequestHandler<DeleteUserInventoryEquippedItemCommand, DeletedUserInventoryEquippedItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserInventoryEquippedItemRepository _userInventoryEquippedItemRepository;
        private readonly UserInventoryEquippedItemBusinessRules _userInventoryEquippedItemBusinessRules;

        public DeleteUserInventoryEquippedItemCommandHandler(IMapper mapper, IUserInventoryEquippedItemRepository userInventoryEquippedItemRepository,
                                         UserInventoryEquippedItemBusinessRules userInventoryEquippedItemBusinessRules)
        {
            _mapper = mapper;
            _userInventoryEquippedItemRepository = userInventoryEquippedItemRepository;
            _userInventoryEquippedItemBusinessRules = userInventoryEquippedItemBusinessRules;
        }

        public async Task<DeletedUserInventoryEquippedItemResponse> Handle(DeleteUserInventoryEquippedItemCommand request, CancellationToken cancellationToken)
        {
            UserInventoryEquippedItem? userInventoryEquippedItem = await _userInventoryEquippedItemRepository.GetAsync(predicate: uiei => uiei.Id == request.Id, cancellationToken: cancellationToken);
            await _userInventoryEquippedItemBusinessRules.UserInventoryEquippedItemShouldExistWhenSelected(userInventoryEquippedItem);

            await _userInventoryEquippedItemRepository.DeleteAsync(userInventoryEquippedItem!);

            DeletedUserInventoryEquippedItemResponse response = _mapper.Map<DeletedUserInventoryEquippedItemResponse>(userInventoryEquippedItem);
            return response;
        }
    }
}