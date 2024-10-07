using Application.Features.UserHeroes.Commands.Create;
using Application.Features.UserHeroes.Commands.Delete;
using Application.Features.UserHeroes.Commands.Update;
using Application.Features.UserHeroes.Queries.GetById;
using Application.Features.UserHeroes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserHeroes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserHeroCommand, UserHero>();
        CreateMap<UserHero, CreatedUserHeroResponse>();

        CreateMap<UpdateUserHeroCommand, UserHero>();
        CreateMap<UserHero, UpdatedUserHeroResponse>();

        CreateMap<DeleteUserHeroCommand, UserHero>();
        CreateMap<UserHero, DeletedUserHeroResponse>();

        CreateMap<UserHero, GetByIdUserHeroResponse>();

        CreateMap<UserHero, GetListUserHeroListItemDto>();
        CreateMap<IPaginate<UserHero>, GetListResponse<GetListUserHeroListItemDto>>();
    }
}