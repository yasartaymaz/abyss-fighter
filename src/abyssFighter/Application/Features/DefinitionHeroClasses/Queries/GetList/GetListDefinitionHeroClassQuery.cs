using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DefinitionHeroClasses.Queries.GetList;

public class GetListDefinitionHeroClassQuery : IRequest<GetListResponse<GetListDefinitionHeroClassListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDefinitionHeroClassQueryHandler : IRequestHandler<GetListDefinitionHeroClassQuery, GetListResponse<GetListDefinitionHeroClassListItemDto>>
    {
        private readonly IDefinitionHeroClassRepository _definitionHeroClassRepository;
        private readonly IMapper _mapper;

        public GetListDefinitionHeroClassQueryHandler(IDefinitionHeroClassRepository definitionHeroClassRepository, IMapper mapper)
        {
            _definitionHeroClassRepository = definitionHeroClassRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDefinitionHeroClassListItemDto>> Handle(GetListDefinitionHeroClassQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DefinitionHeroClass> definitionHeroClasses = await _definitionHeroClassRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDefinitionHeroClassListItemDto> response = _mapper.Map<GetListResponse<GetListDefinitionHeroClassListItemDto>>(definitionHeroClasses);
            return response;
        }
    }
}