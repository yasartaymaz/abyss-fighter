using Application.Features.DefinitionArmorTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmorTypes.Commands.Create;

public class CreateDefinitionArmorTypeCommand : IRequest<CreatedDefinitionArmorTypeResponse>
{
    public string? Value { get; set; }
    public required Guid HeroClassId { get; set; }

    public class CreateDefinitionArmorTypeCommandHandler : IRequestHandler<CreateDefinitionArmorTypeCommand, CreatedDefinitionArmorTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorTypeRepository _definitionArmorTypeRepository;
        private readonly DefinitionArmorTypeBusinessRules _definitionArmorTypeBusinessRules;

        public CreateDefinitionArmorTypeCommandHandler(IMapper mapper, IDefinitionArmorTypeRepository definitionArmorTypeRepository,
                                         DefinitionArmorTypeBusinessRules definitionArmorTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorTypeRepository = definitionArmorTypeRepository;
            _definitionArmorTypeBusinessRules = definitionArmorTypeBusinessRules;
        }

        public async Task<CreatedDefinitionArmorTypeResponse> Handle(CreateDefinitionArmorTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionArmorType definitionArmorType = _mapper.Map<DefinitionArmorType>(request);

            await _definitionArmorTypeRepository.AddAsync(definitionArmorType);

            CreatedDefinitionArmorTypeResponse response = _mapper.Map<CreatedDefinitionArmorTypeResponse>(definitionArmorType);
            return response;
        }
    }
}