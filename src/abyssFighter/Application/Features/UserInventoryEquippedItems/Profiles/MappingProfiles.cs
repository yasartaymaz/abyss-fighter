using Application.Features.UserInventoryEquippedItems.Commands.Create;
using Application.Features.UserInventoryEquippedItems.Commands.Delete;
using Application.Features.UserInventoryEquippedItems.Commands.Update;
using Application.Features.UserInventoryEquippedItems.Queries.GetById;
using Application.Features.UserInventoryEquippedItems.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserInventoryEquippedItems.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserInventoryEquippedItemCommand, UserInventoryEquippedItem>();
        CreateMap<UserInventoryEquippedItem, CreatedUserInventoryEquippedItemResponse>();

        CreateMap<UpdateUserInventoryEquippedItemCommand, UserInventoryEquippedItem>();
        CreateMap<UserInventoryEquippedItem, UpdatedUserInventoryEquippedItemResponse>();

        CreateMap<DeleteUserInventoryEquippedItemCommand, UserInventoryEquippedItem>();
        CreateMap<UserInventoryEquippedItem, DeletedUserInventoryEquippedItemResponse>();

        CreateMap<UserInventoryEquippedItem, GetByIdUserInventoryEquippedItemResponse>();

        CreateMap<UserInventoryEquippedItem, GetListUserInventoryEquippedItemListItemDto>();
        CreateMap<IPaginate<UserInventoryEquippedItem>, GetListResponse<GetListUserInventoryEquippedItemListItemDto>>();
    }
}