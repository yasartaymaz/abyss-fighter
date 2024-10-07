using Application.Features.UserInventories.Commands.Create;
using Application.Features.UserInventories.Commands.Delete;
using Application.Features.UserInventories.Commands.Update;
using Application.Features.UserInventories.Queries.GetById;
using Application.Features.UserInventories.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserInventories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserInventoryCommand, UserInventory>();
        CreateMap<UserInventory, CreatedUserInventoryResponse>();

        CreateMap<UpdateUserInventoryCommand, UserInventory>();
        CreateMap<UserInventory, UpdatedUserInventoryResponse>();

        CreateMap<DeleteUserInventoryCommand, UserInventory>();
        CreateMap<UserInventory, DeletedUserInventoryResponse>();

        CreateMap<UserInventory, GetByIdUserInventoryResponse>();

        CreateMap<UserInventory, GetListUserInventoryListItemDto>();
        CreateMap<IPaginate<UserInventory>, GetListResponse<GetListUserInventoryListItemDto>>();
    }
}