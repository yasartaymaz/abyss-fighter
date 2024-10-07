using Application.Features.UserPetDetails.Commands.Create;
using Application.Features.UserPetDetails.Commands.Delete;
using Application.Features.UserPetDetails.Commands.Update;
using Application.Features.UserPetDetails.Queries.GetById;
using Application.Features.UserPetDetails.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserPetDetails.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserPetDetailCommand, UserPetDetail>();
        CreateMap<UserPetDetail, CreatedUserPetDetailResponse>();

        CreateMap<UpdateUserPetDetailCommand, UserPetDetail>();
        CreateMap<UserPetDetail, UpdatedUserPetDetailResponse>();

        CreateMap<DeleteUserPetDetailCommand, UserPetDetail>();
        CreateMap<UserPetDetail, DeletedUserPetDetailResponse>();

        CreateMap<UserPetDetail, GetByIdUserPetDetailResponse>();

        CreateMap<UserPetDetail, GetListUserPetDetailListItemDto>();
        CreateMap<IPaginate<UserPetDetail>, GetListResponse<GetListUserPetDetailListItemDto>>();
    }
}