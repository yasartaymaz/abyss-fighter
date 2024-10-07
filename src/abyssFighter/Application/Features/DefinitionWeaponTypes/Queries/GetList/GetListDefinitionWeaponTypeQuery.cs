using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionWeaponTypes.Queries.GetList;

public class GetListDefinitionWeaponTypeQuery : IRequest<GetListResponse<GetListDefinitionWeaponTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionWeaponTypeQueryHandler : IRequestHandler<GetListDefinitionWeaponTypeQuery, GetListResponse<GetListDefinitionWeaponTypeListItemDto>>
    {
        private readonly IDefinitionWeaponTypeRepository _definitionWeaponTypeRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionWeaponTypeQueryHandler(IDefinitionWeaponTypeRepository definitionWeaponTypeRepository, IMapper mapper)
        {
            _definitionWeaponTypeRepository = definitionWeaponTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionWeaponTypeListItemDto>> Handle(GetListDefinitionWeaponTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionWeaponType> definitionWeaponTypes = await _definitionWeaponTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionWeaponTypeListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionWeaponTypeListItemDto>>(definitionWeaponTypes);
            return response;
        }
    }
}