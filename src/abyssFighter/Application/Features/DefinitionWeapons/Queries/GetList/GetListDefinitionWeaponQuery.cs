using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionWeapons.Queries.GetList;

public class GetListDefinitionWeaponQuery : IRequest<GetListResponse<GetListDefinitionWeaponListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionWeaponQueryHandler : IRequestHandler<GetListDefinitionWeaponQuery, GetListResponse<GetListDefinitionWeaponListItemDto>>
    {
        private readonly IDefinitionWeaponRepository _definitionWeaponRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionWeaponQueryHandler(IDefinitionWeaponRepository definitionWeaponRepository, IMapper mapper)
        {
            _definitionWeaponRepository = definitionWeaponRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionWeaponListItemDto>> Handle(GetListDefinitionWeaponQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionWeapon> definitionWeapons = await _definitionWeaponRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionWeaponListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionWeaponListItemDto>>(definitionWeapons);
            return response;
        }
    }
}