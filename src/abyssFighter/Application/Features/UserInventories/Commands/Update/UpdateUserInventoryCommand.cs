using Application.Features.UserInventories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserInventories.Commands.Update;

public class UpdateUserInventoryCommand : IRequest<UpdatedUserInventoryResponse>
{
    public Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required Guid UserHeroId { get; set; }
    public required Guid DefinitionItemId { get; set; }
    public required Guid DefinitionItemTypeId { get; set; }
    public required decimal Amount { get; set; }

    public class UpdateUserInventoryCommandHandler : IRequestHandler<UpdateUserInventoryCommand, UpdatedUserInventoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserInventoryRepository _userInventoryRepository;
        private readonly UserInventoryBusinessRules _userInventoryBusinessRules;

        public UpdateUserInventoryCommandHandler(IMapper mapper, IUserInventoryRepository userInventoryRepository,
                                         UserInventoryBusinessRules userInventoryBusinessRules)
        {
            _mapper = mapper;
            _userInventoryRepository = userInventoryRepository;
            _userInventoryBusinessRules = userInventoryBusinessRules;
        }

        public async Task<UpdatedUserInventoryResponse> Handle(UpdateUserInventoryCommand request, CancellationToken cancellationToken)
        {
            UserInventory? userInventory = await _userInventoryRepository.GetAsync(predicate: ui => ui.Id == request.Id, cancellationToken: cancellationToken);
            await _userInventoryBusinessRules.UserInventoryShouldExistWhenSelected(userInventory);
            userInventory = _mapper.Map(request, userInventory);

            await _userInventoryRepository.UpdateAsync(userInventory!);

            UpdatedUserInventoryResponse response = _mapper.Map<UpdatedUserInventoryResponse>(userInventory);
            return response;
        }
    }
}