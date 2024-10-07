using Application.Features.DefinitionArmorParts.Constants;
using Application.Features.DefinitionArmorParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmorParts.Commands.Delete;

public class DeleteDefinitionArmorPartCommand : IRequest<DeletedDefinitionArmorPartResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionArmorPartCommandHandler : IRequestHandler<DeleteDefinitionArmorPartCommand, DeletedDefinitionArmorPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorPartRepository _definitionArmorPartRepository;
        private readonly DefinitionArmorPartBusinessRules _definitionArmorPartBusinessRules;

        public DeleteDefinitionArmorPartCommandHandler(IMapper mapper, IDefinitionArmorPartRepository definitionArmorPartRepository,
                                         DefinitionArmorPartBusinessRules definitionArmorPartBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorPartRepository = definitionArmorPartRepository;
            _definitionArmorPartBusinessRules = definitionArmorPartBusinessRules;
        }

        public async Task<DeletedDefinitionArmorPartResponse> Handle(DeleteDefinitionArmorPartCommand request, CancellationToken cancellationToken)
        {
            DefinitionArmorPart? definitionArmorPart = await _definitionArmorPartRepository.GetAsync(predicate: dap => dap.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionArmorPartBusinessRules.DefinitionArmorPartShouldExistWhenSelected(definitionArmorPart);

            await _definitionArmorPartRepository.DeleteAsync(definitionArmorPart!);

            DeletedDefinitionArmorPartResponse response = _mapper.Map<DeletedDefinitionArmorPartResponse>(definitionArmorPart);
            return response;
        }
    }
}