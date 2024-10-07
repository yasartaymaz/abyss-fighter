using Application.Features.DefinitionItems.Commands.Create;
using Application.Features.DefinitionItems.Commands.Delete;
using Application.Features.DefinitionItems.Commands.Update;
using Application.Features.DefinitionItems.Queries.GetById;
using Application.Features.DefinitionItems.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionItems.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionItemCommand, DefinitionItem>();
        CreateMap<DefinitionItem, CreatedDefinitionItemResponse>();

        CreateMap<UpdateDefinitionItemCommand, DefinitionItem>();
        CreateMap<DefinitionItem, UpdatedDefinitionItemResponse>();

        CreateMap<DeleteDefinitionItemCommand, DefinitionItem>();
        CreateMap<DefinitionItem, DeletedDefinitionItemResponse>();

        CreateMap<DefinitionItem, GetByIdDefinitionItemResponse>();

        CreateMap<DefinitionItem, GetListDefinitionItemListItemDto>();
        CreateMap<IPaginate<DefinitionItem>, GetListResponse<GetListDefinitionItemListItemDto>>();
    }
}