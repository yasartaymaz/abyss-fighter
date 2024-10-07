using Application.Features.DefinitionItemTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionItemTypes.Commands.Create;

public class CreateDefinitionItemTypeCommand : IRequest<CreatedDefinitionItemTypeResponse>
{
    public string? Value { get; set; }

    public class CreateDefinitionItemTypeCommandHandler : IRequestHandler<CreateDefinitionItemTypeCommand, CreatedDefinitionItemTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionItemTypeRepository _definitionItemTypeRepository;
        private readonly DefinitionItemTypeBusinessRules _definitionItemTypeBusinessRules;

        public CreateDefinitionItemTypeCommandHandler(IMapper mapper, IDefinitionItemTypeRepository definitionItemTypeRepository,
                                         DefinitionItemTypeBusinessRules definitionItemTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionItemTypeRepository = definitionItemTypeRepository;
            _definitionItemTypeBusinessRules = definitionItemTypeBusinessRules;
        }

        public async Task<CreatedDefinitionItemTypeResponse> Handle(CreateDefinitionItemTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionItemType definitionItemType = _mapper.Map<DefinitionItemType>(request);

            await _definitionItemTypeRepository.AddAsync(definitionItemType);

            CreatedDefinitionItemTypeResponse response = _mapper.Map<CreatedDefinitionItemTypeResponse>(definitionItemType);
            return response;
        }
    }
}