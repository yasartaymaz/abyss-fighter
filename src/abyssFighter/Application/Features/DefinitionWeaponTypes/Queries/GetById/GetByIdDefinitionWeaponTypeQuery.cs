using Application.Features.DefinitionWeaponTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWeaponTypes.Queries.GetById;

public class GetByIdDefinitionWeaponTypeQuery : IRequest<GetByIdDefinitionWeaponTypeResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionWeaponTypeQueryHandler : IRequestHandler<GetByIdDefinitionWeaponTypeQuery, GetByIdDefinitionWeaponTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWeaponTypeRepository _definitionWeaponTypeRepository;
        private readonly DefinitionWeaponTypeBusinessRules _definitionWeaponTypeBusinessRules;

        public GetByIdDefinitionWeaponTypeQueryHandler(IMapper mapper, IDefinitionWeaponTypeRepository definitionWeaponTypeRepository, DefinitionWeaponTypeBusinessRules definitionWeaponTypeBusinessRules)
        {
            _mapper = mapper;
            _definitionWeaponTypeRepository = definitionWeaponTypeRepository;
            _definitionWeaponTypeBusinessRules = definitionWeaponTypeBusinessRules;
        }

        public async Task<GetByIdDefinitionWeaponTypeResponse> Handle(GetByIdDefinitionWeaponTypeQuery request, CancellationToken cancellationToken)
        {
            DefinitionWeaponType? definitionWeaponType = await _definitionWeaponTypeRepository.GetAsync(predicate: dwt => dwt.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionWeaponTypeBusinessRules.DefinitionWeaponTypeShouldExistWhenSelected(definitionWeaponType);

            GetByIdDefinitionWeaponTypeResponse response = _mapper.Map<GetByIdDefinitionWeaponTypeResponse>(definitionWeaponType);
            return response;
        }
    }
}