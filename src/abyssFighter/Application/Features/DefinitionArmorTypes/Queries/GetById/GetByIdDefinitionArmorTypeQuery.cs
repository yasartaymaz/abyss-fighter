using Application.Features.DefinitionArmorTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionArmorTypes.Queries.GetById;

public class GetByIdDefinitionArmorTypeQuery : IRequest<GetByIdDefinitionArmorTypeResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionArmorTypeQueryHandler : IRequestHandler<GetByIdDefinitionArmorTypeQuery, GetByIdDefinitionArmorTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionArmorTypeRepository _definitionArmorTypeRepository;
        private readonly DefinitionArmorTypeBusinessRules _definitionArmorTypeBusinessRules;

        public GetByIdDefinitionArmorTypeQueryHandler(IMapper mapper, IDefinitionArmorTypeRepository definitionArmorTypeRepository, DefinitionArmorTypeBusinessRules definitionArmorTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionArmorTypeRepository = definitionArmorTypeRepository;
            _definitionArmorTypeBusinessRules = definitionArmorTypeBusinessRules;
        }

        public async Task<GetByIdDefinitionArmorTypeResponse> Handle(GetByIdDefinitionArmorTypeQuery request, CancellationToken cancellationToken)
        {
            DefinitionArmorType? definitionArmorType = await _definitionArmorTypeRepository.GetAsync(predicate: dat => dat.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionArmorTypeBusinessRules.DefinitionArmorTypeShouldExistWhenSelected(definitionArmorType);

            GetByIdDefinitionArmorTypeResponse response = _mapper.Map<GetByIdDefinitionArmorTypeResponse>(definitionArmorType);
            return response;
        }
    }
}