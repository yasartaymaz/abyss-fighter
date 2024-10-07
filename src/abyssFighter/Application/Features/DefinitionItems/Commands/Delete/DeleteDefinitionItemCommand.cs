using Application.Features.DefinitionItems.Constants;
using Application.Features.DefinitionItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionItems.Commands.Delete;

public class DeleteDefinitionItemCommand : IRequest<DeletedDefinitionItemResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionItemCommandHandler : IRequestHandler<DeleteDefinitionItemCommand, DeletedDefinitionItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionItemRepository _definitionItemRepository;
        private readonly DefinitionItemBusinessRules _definitionItemBusinessRules;

        public DeleteDefinitionItemCommandHandler(IMapper mapper, IDefinitionItemRepository definitionItemRepository,
                                         DefinitionItemBusinessRules definitionItemBusinessRules)
        {
            _mapper = mapper;
            _definitionItemRepository = definitionItemRepository;
            _definitionItemBusinessRules = definitionItemBusinessRules;
        }

        public async Task<DeletedDefinitionItemResponse> Handle(DeleteDefinitionItemCommand request, CancellationToken cancellationToken)
        {
            DefinitionItem? definitionItem = await _definitionItemRepository.GetAsync(predicate: di => di.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionItemBusinessRules.DefinitionItemShouldExistWhenSelected(definitionItem);

            await _definitionItemRepository.DeleteAsync(definitionItem!);

            DeletedDefinitionItemResponse response = _mapper.Map<DeletedDefinitionItemResponse>(definitionItem);
            return response;
        }
    }
}