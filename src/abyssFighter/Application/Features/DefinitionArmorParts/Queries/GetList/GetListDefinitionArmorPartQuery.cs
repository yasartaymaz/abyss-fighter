using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionArmorParts.Queries.GetList;

public class GetListDefinitionArmorPartQuery : IRequest<GetListResponse<GetListDefinitionArmorPartListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionArmorPartQueryHandler : IRequestHandler<GetListDefinitionArmorPartQuery, GetListResponse<GetListDefinitionArmorPartListItemDto>>
    {
        private readonly IDefinitionArmorPartRepository _definitionArmorPartRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionArmorPartQueryHandler(IDefinitionArmorPartRepository definitionArmorPartRepository, IMapper mapper)
        {
            _definitionArmorPartRepository = definitionArmorPartRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionArmorPartListItemDto>> Handle(GetListDefinitionArmorPartQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionArmorPart> definitionArmorParts = await _definitionArmorPartRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionArmorPartListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionArmorPartListItemDto>>(definitionArmorParts);
            return response;
        }
    }
}