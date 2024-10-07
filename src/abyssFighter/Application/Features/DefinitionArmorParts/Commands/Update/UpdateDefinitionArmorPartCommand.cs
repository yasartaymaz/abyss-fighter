using Application.Features.DefinitionArmorParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmorParts.Commands.Update;

public class UpdateDefinitionArmorPartCommand : IRequest<UpdatedDefinitionArmorPartResponse>
{
    public Guid Id { get; set; }
    public string? Value { get; set; }

    public class UpdateDefinitionArmorPartCommandHandler : IRequestHandler<UpdateDefinitionArmorPartCommand, UpdatedDefinitionArmorPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorPartRepository _definitionArmorPartRepository;
        private readonly DefinitionArmorPartBusinessRules _definitionArmorPartBusinessRules;

        public UpdateDefinitionArmorPartCommandHandler(IMapper mapper, IDefinitionArmorPartRepository definitionArmorPartRepository,
                                         DefinitionArmorPartBusinessRules definitionArmorPartBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorPartRepository = definitionArmorPartRepository;
            _definitionArmorPartBusinessRules = definitionArmorPartBusinessRules;
        }

        public async Task<UpdatedDefinitionArmorPartResponse> Handle(UpdateDefinitionArmorPartCommand request, CancellationToken cancellationToken)
        {
            DefinitionArmorPart? definitionArmorPart = await _definitionArmorPartRepository.GetAsync(predicate: dap => dap.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionArmorPartBusinessRules.DefinitionArmorPartShouldExistWhenSelected(definitionArmorPart);
            definitionArmorPart = _mapper.Map(request, definitionArmorPart);

            await _definitionArmorPartRepository.UpdateAsync(definitionArmorPart!);

            UpdatedDefinitionArmorPartResponse response = _mapper.Map<UpdatedDefinitionArmorPartResponse>(definitionArmorPart);
            return response;
        }
    }
}