using Application.Features.DefinitionArmors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmors.Queries.GetById;

public class GetByIdDefinitionArmorQuery : IRequest<GetByIdDefinitionArmorResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionArmorQueryHandler : IRequestHandler<GetByIdDefinitionArmorQuery, GetByIdDefinitionArmorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorRepository _definitionArmorRepository;
        private readonly DefinitionArmorBusinessRules _definitionArmorBusinessRules;

        public GetByIdDefinitionArmorQueryHandler(IMapper mapper, IDefinitionArmorRepository definitionArmorRepository, DefinitionArmorBusinessRules definitionArmorBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorRepository = definitionArmorRepository;
            _definitionArmorBusinessRules = definitionArmorBusinessRules;
        }

        public async Task<GetByIdDefinitionArmorResponse> Handle(GetByIdDefinitionArmorQuery request, CancellationToken cancellationToken)
        {
            DefinitionArmor? definitionArmor = await _definitionArmorRepository.GetAsync(predicate: da => da.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionArmorBusinessRules.DefinitionArmorShouldExistWhenSelected(definitionArmor);

            GetByIdDefinitionArmorResponse response = _mapper.Map<GetByIdDefinitionArmorResponse>(definitionArmor);
            return response;
        }
    }
}