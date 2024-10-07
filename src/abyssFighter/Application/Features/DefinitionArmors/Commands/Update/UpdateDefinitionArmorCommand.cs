using Application.Features.DefinitionArmors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmors.Commands.Update;

public class UpdateDefinitionArmorCommand : IRequest<UpdatedDefinitionArmorResponse>
{
    public Guid Id { get; set; }
    public required Guid DefinitionArmorTypeId { get; set; }
    public required Guid DefinitionArmorPartId { get; set; }
    public string? Name { get; set; }
    public required decimal DefencePoints { get; set; }

    public class UpdateDefinitionArmorCommandHandler : IRequestHandler<UpdateDefinitionArmorCommand, UpdatedDefinitionArmorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorRepository _definitionArmorRepository;
        private readonly DefinitionArmorBusinessRules _definitionArmorBusinessRules;

        public UpdateDefinitionArmorCommandHandler(IMapper mapper, IDefinitionArmorRepository definitionArmorRepository,
                                         DefinitionArmorBusinessRules definitionArmorBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorRepository = definitionArmorRepository;
            _definitionArmorBusinessRules = definitionArmorBusinessRules;
        }

        public async Task<UpdatedDefinitionArmorResponse> Handle(UpdateDefinitionArmorCommand request, CancellationToken cancellationToken)
        {
            DefinitionArmor? definitionArmor = await _definitionArmorRepository.GetAsync(predicate: da => da.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionArmorBusinessRules.DefinitionArmorShouldExistWhenSelected(definitionArmor);
            definitionArmor = _mapper.Map(request, definitionArmor);

            await _definitionArmorRepository.UpdateAsync(definitionArmor!);

            UpdatedDefinitionArmorResponse response = _mapper.Map<UpdatedDefinitionArmorResponse>(definitionArmor);
            return response;
        }
    }
}