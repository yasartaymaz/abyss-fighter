using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionPets.Queries.GetList;

public class GetListDefinitionPetQuery : IRequest<GetListResponse<GetListDefinitionPetListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionPetQueryHandler : IRequestHandler<GetListDefinitionPetQuery, GetListResponse<GetListDefinitionPetListItemDto>>
    {
        private readonly IDefinitionPetRepository _definitionPetRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionPetQueryHandler(IDefinitionPetRepository definitionPetRepository, IMapper mapper)
        {
            _definitionPetRepository = definitionPetRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionPetListItemDto>> Handle(GetListDefinitionPetQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionPet> definitionPets = await _definitionPetRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionPetListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionPetListItemDto>>(definitionPets);
            return response;
        }
    }
}