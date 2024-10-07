using Application.Features.DefinitionArmors.Constants;
using Application.Features.DefinitionArmors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmors.Commands.Delete;

public class DeleteDefinitionArmorCommand : IRequest<DeletedDefinitionArmorResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionArmorCommandHandler : IRequestHandler<DeleteDefinitionArmorCommand, DeletedDefinitionArmorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorRepository _definitionArmorRepository;
        private readonly DefinitionArmorBusinessRules _definitionArmorBusinessRules;

        public DeleteDefinitionArmorCommandHandler(IMapper mapper, IDefinitionArmorRepository definitionArmorRepository,
                                         DefinitionArmorBusinessRules definitionArmorBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorRepository = definitionArmorRepository;
            _definitionArmorBusinessRules = definitionArmorBusinessRules;
        }

        public async Task<DeletedDefinitionArmorResponse> Handle(DeleteDefinitionArmorCommand request, CancellationToken cancellationToken)
        {
            DefinitionArmor? definitionArmor = await _definitionArmorRepository.GetAsync(predicate: da => da.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionArmorBusinessRules.DefinitionArmorShouldExistWhenSelected(definitionArmor);

            await _definitionArmorRepository.DeleteAsync(definitionArmor!);

            DeletedDefinitionArmorResponse response = _mapper.Map<DeletedDefinitionArmorResponse>(definitionArmor);
            return response;
        }
    }
}