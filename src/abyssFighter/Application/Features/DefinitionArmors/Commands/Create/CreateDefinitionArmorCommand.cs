using Application.Features.DefinitionArmors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmors.Commands.Create;

public class CreateDefinitionArmorCommand : IRequest<CreatedDefinitionArmorResponse>
{
    public required Guid DefinitionArmorTypeId { get; set; }
    public required Guid DefinitionArmorPartId { get; set; }
    public string? Name { get; set; }
    public required decimal DefencePoints { get; set; }

    public class CreateDefinitionArmorCommandHandler : IRequestHandler<CreateDefinitionArmorCommand, CreatedDefinitionArmorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorRepository _definitionArmorRepository;
        private readonly DefinitionArmorBusinessRules _definitionArmorBusinessRules;

        public CreateDefinitionArmorCommandHandler(IMapper mapper, IDefinitionArmorRepository definitionArmorRepository,
                                         DefinitionArmorBusinessRules definitionArmorBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorRepository = definitionArmorRepository;
            _definitionArmorBusinessRules = definitionArmorBusinessRules;
        }

        public async Task<CreatedDefinitionArmorResponse> Handle(CreateDefinitionArmorCommand request, CancellationToken cancellationToken)
        {
            DefinitionArmor definitionArmor = _mapper.Map<DefinitionArmor>(request);

            await _definitionArmorRepository.AddAsync(definitionArmor);

            CreatedDefinitionArmorResponse response = _mapper.Map<CreatedDefinitionArmorResponse>(definitionArmor);
            return response;
        }
    }
}