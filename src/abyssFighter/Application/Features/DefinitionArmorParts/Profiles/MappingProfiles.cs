using Application.Features.DefinitionArmorParts.Commands.Create;
using Application.Features.DefinitionArmorParts.Commands.Delete;
using Application.Features.DefinitionArmorParts.Commands.Update;
using Application.Features.DefinitionArmorParts.Queries.GetById;
using Application.Features.DefinitionArmorParts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DefinitionArmorParts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDefinitionArmorPartCommand, DefinitionArmorPart>();
        CreateMap<DefinitionArmorPart, CreatedDefinitionArmorPartResponse>();

        CreateMap<UpdateDefinitionArmorPartCommand, DefinitionArmorPart>();
        CreateMap<DefinitionArmorPart, UpdatedDefinitionArmorPartResponse>();

        CreateMap<DeleteDefinitionArmorPartCommand, DefinitionArmorPart>();
        CreateMap<DefinitionArmorPart, DeletedDefinitionArmorPartResponse>();

        CreateMap<DefinitionArmorPart, GetByIdDefinitionArmorPartResponse>();

        CreateMap<DefinitionArmorPart, GetListDefinitionArmorPartListItemDto>();
        CreateMap<IPaginate<DefinitionArmorPart>, GetListResponse<GetListDefinitionArmorPartListItemDto>>();
    }
}