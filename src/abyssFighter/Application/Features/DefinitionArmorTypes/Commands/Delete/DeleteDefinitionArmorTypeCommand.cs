using Application.Features.DefinitionArmorTypes.Constants;
using Application.Features.DefinitionArmorTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmorTypes.Commands.Delete;

public class DeleteDefinitionArmorTypeCommand : IRequest<DeletedDefinitionArmorTypeResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionArmorTypeCommandHandler : IRequestHandler<DeleteDefinitionArmorTypeCommand, DeletedDefinitionArmorTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorTypeRepository _definitionArmorTypeRepository;
        private readonly DefinitionArmorTypeBusinessRules _definitionArmorTypeBusinessRules;

        public DeleteDefinitionArmorTypeCommandHandler(IMapper mapper, IDefinitionArmorTypeRepository definitionArmorTypeRepository,
                                         DefinitionArmorTypeBusinessRules definitionArmorTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorTypeRepository = definitionArmorTypeRepository;
            _definitionArmorTypeBusinessRules = definitionArmorTypeBusinessRules;
        }

        public async Task<DeletedDefinitionArmorTypeResponse> Handle(DeleteDefinitionArmorTypeCommand request, CancellationToken cancellationToken)
        {
            DefinitionArmorType? definitionArmorType = await _definitionArmorTypeRepository.GetAsync(predicate: dat => dat.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionArmorTypeBusinessRules.DefinitionArmorTypeShouldExistWhenSelected(definitionArmorType);

            await _definitionArmorTypeRepository.DeleteAsync(definitionArmorType!);

            DeletedDefinitionArmorTypeResponse response = _mapper.Map<DeletedDefinitionArmorTypeResponse>(definitionArmorType);
            return response;
        }
    }
}