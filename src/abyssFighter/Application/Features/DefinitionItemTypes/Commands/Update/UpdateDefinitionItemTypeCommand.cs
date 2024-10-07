using Application.Features.DefinitionItemTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionItemTypes.Commands.Update;

public class UpdateDefinitionItemTypeCommand : IRequest<UpdatedDefinitionItemTypeResponse>
{
    public Guid Id { get; set; }
    public string? Value { get; set; }

    public class UpdateDefinitionItemTypeCommandHandler : IRequestHandler<UpdateDefinitionItemTypeCommand, UpdatedDefinitionItemTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionItemTypeRepository _definitionItemTypeRepository;
        private readonly DefinitionItemTypeBusinessRules _definitionItemTypeBusinessRules;

        public UpdateDefinitionItemTypeCommandHandler(IMapper mapper, IDefinitionItemTypeRepository definitionItemTypeRepository,
                                         DefinitionItemTypeBusinessRules definitionItemTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionItemTypeRepository = definitionItemTypeRepository;
            _definitionItemTypeBusinessRules = definitionItemTypeBusinessRules;
        }

        public async Task<UpdatedDefinitionItemTypeResponse> Handle(UpdateDefinitionItemTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionItemType? definitionItemType = await _definitionItemTypeRepository.GetAsync(predicate: dit => dit.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionItemTypeBusinessRules.DefinitionItemTypeShouldExistWhenSelected(definitionItemType);
            definitionItemType = _mapper.Map(request, definitionItemType);

            await _definitionItemTypeRepository.UpdateAsync(definitionItemType!);

            UpdatedDefinitionItemTypeResponse response = _mapper.Map<UpdatedDefinitionItemTypeResponse>(definitionItemType);
            return response;
        }
    }
}