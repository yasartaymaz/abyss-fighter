using Application.Features.UserInventories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserInventories.Queries.GetById;

public class GetByIdUserInventoryQuery : IRequest<GetByIdUserInventoryResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUserInventoryQueryHandler : IRequestHandler<GetByIdUserInventoryQuery, GetByIdUserInventoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserInventoryRepository _userInventoryRepository;
        private readonly UserInventoryBusinessRules _userInventoryBusinessRules;

        public GetByIdUserInventoryQueryHandler(IMapper mapper, IUserInventoryRepository userInventoryRepository, UserInventoryBusinessRules userInventoryBusinessRules)
        {
            _mapper = mapper;
            _userInventoryRepository = userInventoryRepository;
            _userInventoryBusinessRules = userInventoryBusinessRules;
        }

        public async Task<GetByIdUserInventoryResponse> Handle(GetByIdUserInventoryQuery request, CancellationToken cancellationToken)
        {
            UserInventory? userInventory = await _userInventoryRepository.GetAsync(predicate: ui => ui.Id == request.Id, cancellationToken: cancellationToken);
            await _userInventoryBusinessRules.UserInventoryShouldExistWhenSelected(userInventory);

            GetByIdUserInventoryResponse response = _mapper.Map<GetByIdUserInventoryResponse>(userInventory);
            return response;
        }
    }
}