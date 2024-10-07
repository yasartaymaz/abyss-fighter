using Application.Features.UserPets.Commands.Create;
using Application.Features.UserPets.Commands.Delete;
using Application.Features.UserPets.Commands.Update;
using Application.Features.UserPets.Queries.GetById;
using Application.Features.UserPets.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserPets.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserPetCommand, UserPet>();
        CreateMap<UserPet, CreatedUserPetResponse>();

        CreateMap<UpdateUserPetCommand, UserPet>();
        CreateMap<UserPet, UpdatedUserPetResponse>();

        CreateMap<DeleteUserPetCommand, UserPet>();
        CreateMap<UserPet, DeletedUserPetResponse>();

        CreateMap<UserPet, GetByIdUserPetResponse>();

        CreateMap<UserPet, GetListUserPetListItemDto>();
        CreateMap<IPaginate<UserPet>, GetListResponse<GetListUserPetListItemDto>>();
    }
}