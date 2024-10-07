using Application.Features.UserWallets.Commands.Create;
using Application.Features.UserWallets.Commands.Delete;
using Application.Features.UserWallets.Commands.Update;
using Application.Features.UserWallets.Queries.GetById;
using Application.Features.UserWallets.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserWallets.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserWalletCommand, UserWallet>();
        CreateMap<UserWallet, CreatedUserWalletResponse>();

        CreateMap<UpdateUserWalletCommand, UserWallet>();
        CreateMap<UserWallet, UpdatedUserWalletResponse>();

        CreateMap<DeleteUserWalletCommand, UserWallet>();
        CreateMap<UserWallet, DeletedUserWalletResponse>();

        CreateMap<UserWallet, GetByIdUserWalletResponse>();

        CreateMap<UserWallet, GetListUserWalletListItemDto>();
        CreateMap<IPaginate<UserWallet>, GetListResponse<GetListUserWalletListItemDto>>();
    }
}