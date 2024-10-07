using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionItemTypes.Queries.GetList;

public class GetListDefinitionItemTypeQuery : IRequest<GetListResponse<GetListDefinitionItemTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionItemTypeQueryHandler : IRequestHandler<GetListDefinitionItemTypeQuery, GetListResponse<GetListDefinitionItemTypeListItemDto>>
    {
        private readonly IDefinitionItemTypeRepository _definitionItemTypeRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionItemTypeQueryHandler(IDefinitionItemTypeRepository definitionItemTypeRepository, IMapper mapper)
        {
            _definitionItemTypeRepository = definitionItemTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionItemTypeListItemDto>> Handle(GetListDefinitionItemTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionItemType> definitionItemTypes = await _definitionItemTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionItemTypeListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionItemTypeListItemDto>>(definitionItemTypes);
            return response;
        }
    }
}