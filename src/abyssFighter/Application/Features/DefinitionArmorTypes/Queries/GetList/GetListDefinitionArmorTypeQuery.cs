using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionArmorTypes.Queries.GetList;

public class GetListDefinitionArmorTypeQuery : IRequest<GetListResponse<GetListDefinitionArmorTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionArmorTypeQueryHandler : IRequestHandler<GetListDefinitionArmorTypeQuery, GetListResponse<GetListDefinitionArmorTypeListItemDto>>
    {
        private readonly IDefinitionArmorTypeRepository _definitionArmorTypeRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionArmorTypeQueryHandler(IDefinitionArmorTypeRepository definitionArmorTypeRepository, IMapper mapper)
        {
            _definitionArmorTypeRepository = definitionArmorTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionArmorTypeListItemDto>> Handle(GetListDefinitionArmorTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionArmorType> definitionArmorTypes = await _definitionArmorTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionArmorTypeListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionArmorTypeListItemDto>>(definitionArmorTypes);
            return response;
        }
    }
}