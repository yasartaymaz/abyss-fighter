using Application.Features.DefinitionWalletTypes.Commands.Create;
using Application.Features.DefinitionWalletTypes.Commands.Delete;
using Application.Features.DefinitionWalletTypes.Commands.Update;
using Application.Features.DefinitionWalletTypes.Queries.GetById;
using Application.Features.DefinitionWalletTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionWalletTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionWalletTypeCommand, DefinitionWalletType>();
        CreateMap<DefinitionWalletType, CreatedDefinitionWalletTypeResponse>();

        CreateMap<UpdateDefinitionWalletTypeCommand, DefinitionWalletType>();
        CreateMap<DefinitionWalletType, UpdatedDefinitionWalletTypeResponse>();

        CreateMap<DeleteDefinitionWalletTypeCommand, DefinitionWalletType>();
        CreateMap<DefinitionWalletType, DeletedDefinitionWalletTypeResponse>();

        CreateMap<DefinitionWalletType, GetByIdDefinitionWalletTypeResponse>();

        CreateMap<DefinitionWalletType, GetListDefinitionWalletTypeListItemDto>();
        CreateMap<IPaginate<DefinitionWalletType>, GetListResponse<GetListDefinitionWalletTypeListItemDto>>();
    }
}