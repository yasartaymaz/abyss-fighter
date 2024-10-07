using Application.Features.DefinitionArmorTypes.Commands.Create;
using Application.Features.DefinitionArmorTypes.Commands.Delete;
using Application.Features.DefinitionArmorTypes.Commands.Update;
using Application.Features.DefinitionArmorTypes.Queries.GetById;
using Application.Features.DefinitionArmorTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionArmorTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionArmorTypeCommand, DefinitionArmorType>();
        CreateMap<DefinitionArmorType, CreatedDefinitionArmorTypeResponse>();

        CreateMap<UpdateDefinitionArmorTypeCommand, DefinitionArmorType>();
        CreateMap<DefinitionArmorType, UpdatedDefinitionArmorTypeResponse>();

        CreateMap<DeleteDefinitionArmorTypeCommand, DefinitionArmorType>();
        CreateMap<DefinitionArmorType, DeletedDefinitionArmorTypeResponse>();

        CreateMap<DefinitionArmorType, GetByIdDefinitionArmorTypeResponse>();

        CreateMap<DefinitionArmorType, GetListDefinitionArmorTypeListItemDto>();
        CreateMap<IPaginate<DefinitionArmorType>, GetListResponse<GetListDefinitionArmorTypeListItemDto>>();
    }
}