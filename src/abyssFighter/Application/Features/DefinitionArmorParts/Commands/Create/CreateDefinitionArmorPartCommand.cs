using Application.Features.DefinitionArmorParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmorParts.Commands.Create;

public class CreateDefinitionArmorPartCommand : IRequest<CreatedDefinitionArmorPartResponse>
{
    public string? Value { get; set; }

    public class CreateDefinitionArmorPartCommandHandler : IRequestHandler<CreateDefinitionArmorPartCommand, CreatedDefinitionArmorPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorPartRepository _definitionArmorPartRepository;
        private readonly DefinitionArmorPartBusinessRules _definitionArmorPartBusinessRules;

        public CreateDefinitionArmorPartCommandHandler(IMapper mapper, IDefinitionArmorPartRepository definitionArmorPartRepository,
                                         DefinitionArmorPartBusinessRules definitionArmorPartBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorPartRepository = definitionArmorPartRepository;
            _definitionArmorPartBusinessRules = definitionArmorPartBusinessRules;
        }

        public async Task<CreatedDefinitionArmorPartResponse> Handle(CreateDefinitionArmorPartCommand request, CancellationToken cancellationToken)
        {
            DefinitionArmorPart definitionArmorPart = _mapper.Map<DefinitionArmorPart>(request);

            await _definitionArmorPartRepository.AddAsync(definitionArmorPart);

            CreatedDefinitionArmorPartResponse response = _mapper.Map<CreatedDefinitionArmorPartResponse>(definitionArmorPart);
            return response;
        }
    }
}