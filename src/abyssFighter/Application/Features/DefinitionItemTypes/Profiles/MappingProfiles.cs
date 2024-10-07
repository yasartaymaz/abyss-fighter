using Application.Features.DefinitionItemTypes.Commands.Create;
using Application.Features.DefinitionItemTypes.Commands.Delete;
using Application.Features.DefinitionItemTypes.Commands.Update;
using Application.Features.DefinitionItemTypes.Queries.GetById;
using Application.Features.DefinitionItemTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionItemTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionItemTypeCommand, DefinitionItemType>();
        CreateMap<DefinitionItemType, CreatedDefinitionItemTypeResponse>();

        CreateMap<UpdateDefinitionItemTypeCommand, DefinitionItemType>();
        CreateMap<DefinitionItemType, UpdatedDefinitionItemTypeResponse>();

        CreateMap<DeleteDefinitionItemTypeCommand, DefinitionItemType>();
        CreateMap<DefinitionItemType, DeletedDefinitionItemTypeResponse>();

        CreateMap<DefinitionItemType, GetByIdDefinitionItemTypeResponse>();

        CreateMap<DefinitionItemType, GetListDefinitionItemTypeListItemDto>();
        CreateMap<IPaginate<DefinitionItemType>, GetListResponse<GetListDefinitionItemTypeListItemDto>>();
    }
}