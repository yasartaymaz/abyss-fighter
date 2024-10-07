using Application.Features.DefinitionWeapons.Commands.Create;
using Application.Features.DefinitionWeapons.Commands.Delete;
using Application.Features.DefinitionWeapons.Commands.Update;
using Application.Features.DefinitionWeapons.Queries.GetById;
using Application.Features.DefinitionWeapons.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionWeapons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionWeaponCommand, DefinitionWeapon>();
        CreateMap<DefinitionWeapon, CreatedDefinitionWeaponResponse>();

        CreateMap<UpdateDefinitionWeaponCommand, DefinitionWeapon>();
        CreateMap<DefinitionWeapon, UpdatedDefinitionWeaponResponse>();

        CreateMap<DeleteDefinitionWeaponCommand, DefinitionWeapon>();
        CreateMap<DefinitionWeapon, DeletedDefinitionWeaponResponse>();

        CreateMap<DefinitionWeapon, GetByIdDefinitionWeaponResponse>();

        CreateMap<DefinitionWeapon, GetListDefinitionWeaponListItemDto>();
        CreateMap<IPaginate<DefinitionWeapon>, GetListResponse<GetListDefinitionWeaponListItemDto>>();
    }
}