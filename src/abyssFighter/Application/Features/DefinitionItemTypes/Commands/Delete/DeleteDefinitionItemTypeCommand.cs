using Application.Features.DefinitionItemTypes.Constants;
using Application.Features.DefinitionItemTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionItemTypes.Commands.Delete;

public class DeleteDefinitionItemTypeCommand : IRequest<DeletedDefinitionItemTypeResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionItemTypeCommandHandler : IRequestHandler<DeleteDefinitionItemTypeCommand, DeletedDefinitionItemTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionItemTypeRepository _definitionItemTypeRepository;
        private readonly DefinitionItemTypeBusinessRules _definitionItemTypeBusinessRules;

        public DeleteDefinitionItemTypeCommandHandler(IMapper mapper, IDefinitionItemTypeRepository definitionItemTypeRepository,
                                         DefinitionItemTypeBusinessRules definitionItemTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionItemTypeRepository = definitionItemTypeRepository;
            _definitionItemTypeBusinessRules = definitionItemTypeBusinessRules;
        }

        public async Task<DeletedDefinitionItemTypeResponse> Handle(DeleteDefinitionItemTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionItemType? definitionItemType = await _definitionItemTypeRepository.GetAsync(predicate: dit => dit.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionItemTypeBusinessRules.DefinitionItemTypeShouldExistWhenSelected(definitionItemType);

            await _definitionItemTypeRepository.DeleteAsync(definitionItemType!);

            DeletedDefinitionItemTypeResponse response = _mapper.Map<DeletedDefinitionItemTypeResponse>(definitionItemType);
            return response;
        }
    }
}