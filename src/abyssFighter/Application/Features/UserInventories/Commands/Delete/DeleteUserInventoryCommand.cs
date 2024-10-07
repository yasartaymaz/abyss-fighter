using Application.Features.UserInventories.Constants;
using Application.Features.UserInventories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserInventories.Commands.Delete;

public class DeleteUserInventoryCommand : IRequest<DeletedUserInventoryResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserInventoryCommandHandler : IRequestHandler<DeleteUserInventoryCommand, DeletedUserInventoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserInventoryRepository _userInventoryRepository;
        private readonly UserInventoryBusinessRules _userInventoryBusinessRules;

        public DeleteUserInventoryCommandHandler(IMapper mapper, IUserInventoryRepository userInventoryRepository,
                                         UserInventoryBusinessRules userInventoryBusinessRules)
        {
            _mapper = mapper;
            _userInventoryRepository = userInventoryRepository;
            _userInventoryBusinessRules = userInventoryBusinessRules;
        }

        public async Task<DeletedUserInventoryResponse> Handle(DeleteUserInventoryCommand request, CancellationToken cancellationToken)
        {
            UserInventory? userInventory = await _userInventoryRepository.GetAsync(predicate: ui => ui.Id == request.Id, cancellationToken: cancellationToken);
            await _userInventoryBusinessRules.UserInventoryShouldExistWhenSelected(userInventory);

            await _userInventoryRepository.DeleteAsync(userInventory!);

            DeletedUserInventoryResponse response = _mapper.Map<DeletedUserInventoryResponse>(userInventory);
            return response;
        }
    }
}