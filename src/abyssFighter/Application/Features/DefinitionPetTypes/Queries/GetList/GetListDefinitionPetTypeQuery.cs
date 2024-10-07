using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionPetTypes.Queries.GetList;

public class GetListDefinitionPetTypeQuery : IRequest<GetListResponse<GetListDefinitionPetTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionPetTypeQueryHandler : IRequestHandler<GetListDefinitionPetTypeQuery, GetListResponse<GetListDefinitionPetTypeListItemDto>>
    {
        private readonly IDefinitionPetTypeRepository _definitionPetTypeRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionPetTypeQueryHandler(IDefinitionPetTypeRepository definitionPetTypeRepository, IMapper mapper)
        {
            _definitionPetTypeRepository = definitionPetTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionPetTypeListItemDto>> Handle(GetListDefinitionPetTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionPetType> definitionPetTypes = await _definitionPetTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionPetTypeListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionPetTypeListItemDto>>(definitionPetTypes);
            return response;
        }
    }
}