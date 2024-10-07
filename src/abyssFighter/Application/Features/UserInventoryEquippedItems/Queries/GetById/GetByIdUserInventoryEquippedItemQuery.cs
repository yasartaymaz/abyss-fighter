using Application.Features.UserInventoryEquippedItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserInventoryEquippedItems.Queries.GetById;

public class GetByIdUserInventoryEquippedItemQuery : IRequest<GetByIdUserInventoryEquippedItemResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUserInventoryEquippedItemQueryHandler : IRequestHandler<GetByIdUserInventoryEquippedItemQuery, GetByIdUserInventoryEquippedItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserInventoryEquippedItemRepository _userInventoryEquippedItemRepository;
        private readonly UserInventoryEquippedItemBusinessRules _userInventoryEquippedItemBusinessRules;

        public GetByIdUserInventoryEquippedItemQueryHandler(IMapper mapper, IUserInventoryEquippedItemRepository userInventoryEquippedItemRepository, UserInventoryEquippedItemBusinessRules userInventoryEquippedItemBusinessRules)
        {
            _mapper = mapper;
            _userInventoryEquippedItemRepository = userInventoryEquippedItemRepository;
            _userInventoryEquippedItemBusinessRules = userInventoryEquippedItemBusinessRules;
        }

        public async Task<GetByIdUserInventoryEquippedItemResponse> Handle(GetByIdUserInventoryEquippedItemQuery request, CancellationToken cancellationToken)
        {
            UserInventoryEquippedItem? userInventoryEquippedItem = await _userInventoryEquippedItemRepository.GetAsync(predicate: uiei => uiei.Id == request.Id, cancellationToken: cancellationToken);
            await _userInventoryEquippedItemBusinessRules.UserInventoryEquippedItemShouldExistWhenSelected(userInventoryEquippedItem);

            GetByIdUserInventoryEquippedItemResponse response = _mapper.Map<GetByIdUserInventoryEquippedItemResponse>(userInventoryEquippedItem);
            return response;
        }
    }
}