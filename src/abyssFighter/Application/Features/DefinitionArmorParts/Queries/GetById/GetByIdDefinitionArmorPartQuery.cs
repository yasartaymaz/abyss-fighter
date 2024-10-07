using Application.Features.DefinitionArmorParts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmorParts.Queries.GetById;

public class GetByIdDefinitionArmorPartQuery : IRequest<GetByIdDefinitionArmorPartResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionArmorPartQueryHandler : IRequestHandler<GetByIdDefinitionArmorPartQuery, GetByIdDefinitionArmorPartResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorPartRepository _definitionArmorPartRepository;
        private readonly DefinitionArmorPartBusinessRules _definitionArmorPartBusinessRules;

        public GetByIdDefinitionArmorPartQueryHandler(IMapper mapper, IDefinitionArmorPartRepository definitionArmorPartRepository, DefinitionArmorPartBusinessRules definitionArmorPartBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorPartRepository = definitionArmorPartRepository;
            _definitionArmorPartBusinessRules = definitionArmorPartBusinessRules;
        }

        public async Task<GetByIdDefinitionArmorPartResponse> Handle(GetByIdDefinitionArmorPartQuery request, CancellationToken cancellationToken)
        {
            DefinitionArmorPart? definitionArmorPart = await _definitionArmorPartRepository.GetAsync(predicate: dap => dap.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionArmorPartBusinessRules.DefinitionArmorPartShouldExistWhenSelected(definitionArmorPart);

            GetByIdDefinitionArmorPartResponse response = _mapper.Map<GetByIdDefinitionArmorPartResponse>(definitionArmorPart);
            return response;
        }
    }
}