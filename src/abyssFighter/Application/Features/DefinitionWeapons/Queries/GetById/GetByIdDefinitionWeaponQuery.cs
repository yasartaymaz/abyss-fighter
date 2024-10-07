using Application.Features.DefinitionWeapons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionWeapons.Queries.GetById;

public class GetByIdDefinitionWeaponQuery : IRequest<GetByIdDefinitionWeaponResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDefinitionWeaponQueryHandler : IRequestHandler<GetByIdDefinitionWeaponQuery, GetByIdDefinitionWeaponResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionWeaponRepository _definitionWeaponRepository;
        private readonly DefinitionWeaponBusinessRules _definitionWeaponBusinessRules;

        public GetByIdDefinitionWeaponQueryHandler(IMapper mapper, IDefinitionWeaponRepository definitionWeaponRepository, DefinitionWeaponBusinessRules definitionWeaponBusinessRules)
        {
            _mapper = mapper;
            _definitionWeaponRepository = definitionWeaponRepository;
            _definitionWeaponBusinessRules = definitionWeaponBusinessRules;
        }

        public async Task<GetByIdDefinitionWeaponResponse> Handle(GetByIdDefinitionWeaponQuery request, CancellationToken cancellationToken)
        {
            DefinitionWeapon? definitionWeapon = await _definitionWeaponRepository.GetAsync(predicate: dw => dw.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionWeaponBusinessRules.DefinitionWeaponShouldExistWhenSelected(definitionWeapon);

            GetByIdDefinitionWeaponResponse response = _mapper.Map<GetByIdDefinitionWeaponResponse>(definitionWeapon);
            return response;
        }
    }
}