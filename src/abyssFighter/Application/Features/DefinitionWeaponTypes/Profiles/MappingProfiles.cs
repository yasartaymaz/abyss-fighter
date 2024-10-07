using Application.Features.DefinitionWeaponTypes.Commands.Create;
using Application.Features.DefinitionWeaponTypes.Commands.Delete;
using Application.Features.DefinitionWeaponTypes.Commands.Update;
using Application.Features.DefinitionWeaponTypes.Queries.GetById;
using Application.Features.DefinitionWeaponTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionWeaponTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionWeaponTypeCommand, DefinitionWeaponType>();
        CreateMap<DefinitionWeaponType, CreatedDefinitionWeaponTypeResponse>();

        CreateMap<UpdateDefinitionWeaponTypeCommand, DefinitionWeaponType>();
        CreateMap<DefinitionWeaponType, UpdatedDefinitionWeaponTypeResponse>();

        CreateMap<DeleteDefinitionWeaponTypeCommand, DefinitionWeaponType>();
        CreateMap<DefinitionWeaponType, DeletedDefinitionWeaponTypeResponse>();

        CreateMap<DefinitionWeaponType, GetByIdDefinitionWeaponTypeResponse>();

        CreateMap<DefinitionWeaponType, GetListDefinitionWeaponTypeListItemDto>();
        CreateMap<IPaginate<DefinitionWeaponType>, GetListResponse<GetListDefinitionWeaponTypeListItemDto>>();
    }
}