using Application.Features.DefinitionItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionItems.Commands.Update;

public class UpdateDefinitionItemCommand : IRequest<UpdatedDefinitionItemResponse>
{
    public Guid Id { get; set; }
    public required Guid DefinitionItemTypeId { get; set; }
    public required Guid ItemId { get; set; }
    public required bool IsStackable { get; set; }
    public required bool IsWeapon { get; set; }
    public required bool IsArmor { get; set; }

    public class UpdateDefinitionItemCommandHandler : IRequestHandler<UpdateDefinitionItemCommand, UpdatedDefinitionItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionItemRepository _definitionItemRepository;
        private readonly DefinitionItemBusinessRules _definitionItemBusinessRules;

        public UpdateDefinitionItemCommandHandler(IMapper mapper, IDefinitionItemRepository definitionItemRepository,
                                         DefinitionItemBusinessRules definitionItemBusinessRules)
        {
            _mapper = mapper;
            _definitionItemRepository = definitionItemRepository;
            _definitionItemBusinessRules = definitionItemBusinessRules;
        }

        public async Task<UpdatedDefinitionItemResponse> Handle(UpdateDefinitionItemCommand request, CancellationToken cancellationToken)
        {
            DefinitionItem? definitionItem = await _definitionItemRepository.GetAsync(predicate: di => di.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionItemBusinessRules.DefinitionItemShouldExistWhenSelected(definitionItem);
            definitionItem = _mapper.Map(request, definitionItem);

            await _definitionItemRepository.UpdateAsync(definitionItem!);

            UpdatedDefinitionItemResponse response = _mapper.Map<UpdatedDefinitionItemResponse>(definitionItem);
            return response;
        }
    }
}