using Application.Features.DefinitionArmorTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmorTypes.Commands.Update;

public class UpdateDefinitionArmorTypeCommand : IRequest<UpdatedDefinitionArmorTypeResponse>
{
    public Guid Id { get; set; }
    public string? Value { get; set; }

    public class UpdateDefinitionArmorTypeCommandHandler : IRequestHandler<UpdateDefinitionArmorTypeCommand, UpdatedDefinitionArmorTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorTypeRepository _definitionArmorTypeRepository;
        private readonly DefinitionArmorTypeBusinessRules _definitionArmorTypeBusinessRules;

        public UpdateDefinitionArmorTypeCommandHandler(IMapper mapper, IDefinitionArmorTypeRepository definitionArmorTypeRepository,
                                         DefinitionArmorTypeBusinessRules definitionArmorTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorTypeRepository = definitionArmorTypeRepository;
            _definitionArmorTypeBusinessRules = definitionArmorTypeBusinessRules;
        }

        public async Task<UpdatedDefinitionArmorTypeResponse> Handle(UpdateDefinitionArmorTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionArmorType? definitionArmorType = await _definitionArmorTypeRepository.GetAsync(predicate: dat => dat.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionArmorTypeBusinessRules.DefinitionArmorTypeShouldExistWhenSelected(definitionArmorType);
            definitionArmorType = _mapper.Map(request, definitionArmorType);

            await _definitionArmorTypeRepository.UpdateAsync(definitionArmorType!);

            UpdatedDefinitionArmorTypeResponse response = _mapper.Map<UpdatedDefinitionArmorTypeResponse>(definitionArmorType);
            return response;
        }
    }
}