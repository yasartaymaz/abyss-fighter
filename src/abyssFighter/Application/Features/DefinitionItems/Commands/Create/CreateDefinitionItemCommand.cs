using Application.Features.DefinitionItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionItems.Commands.Create;

public class CreateDefinitionItemCommand : IRequest<CreatedDefinitionItemResponse>
{
    public required Guid DefinitionItemTypeId { get; set; }
    public required Guid ItemId { get; set; }
    public required bool IsStackable { get; set; }
    public required bool IsWeapon { get; set; }
    public required bool IsArmor { get; set; }

    public class CreateDefinitionItemCommandHandler : IRequestHandler<CreateDefinitionItemCommand, CreatedDefinitionItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionItemRepository _definitionItemRepository;
        private readonly DefinitionItemBusinessRules _definitionItemBusinessRules;

        public CreateDefinitionItemCommandHandler(IMapper mapper, IDefinitionItemRepository definitionItemRepository,
                                         DefinitionItemBusinessRules definitionItemBusinessRules)
        {
            _mapper = mapper;
            _definitionItemRepository = definitionItemRepository;
            _definitionItemBusinessRules = definitionItemBusinessRules;
        }

        public async Task<CreatedDefinitionItemResponse> Handle(CreateDefinitionItemCommand request, CancellationToken cancellationToken)
        {
            DefinitionItem definitionItem = _mapper.Map<DefinitionItem>(request);

            await _definitionItemRepository.AddAsync(definitionItem);

            CreatedDefinitionItemResponse response = _mapper.Map<CreatedDefinitionItemResponse>(definitionItem);
            return response;
        }
    }
}