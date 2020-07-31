
namespace IADocumentClassifier.Infrastructure.Mappings
{
    using AutoMapper;
    using IADocumentClassifier.Cors.DTOs;
    using IADocumentClassifier.Cors.Entities;

    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<DocumentsType, DocumentsTypeDTO>();
            CreateMap<DocumentsTypeDTO, DocumentsType>();

            CreateMap<Tags, TagDTO>();
            CreateMap<TagDTO, Tags>();

            CreateMap<Clients, ClientsDTO>();
            CreateMap<ClientsDTO, Clients>();

            CreateMap<ClientDocumentType, ClientDocumentTypeDTO>();
            CreateMap<ClientDocumentTypeDTO, ClientDocumentType>();

            CreateMap<ClientTag, ClientTagDTO>();
            CreateMap<ClientTagDTO, ClientTag>();

            CreateMap<Permissions, PermissionsDTO>();
            CreateMap<PermissionsDTO, Permissions>();

            CreateMap<Roles, RolesDTO>();
            CreateMap<RolesDTO, Roles>();

            CreateMap<RolesClient, RolesClientDTO>();
            CreateMap<RolesClientDTO, RolesClient>();

            CreateMap<RolesPermission, RolesPermissionDTO>();
            CreateMap<RolesPermissionDTO, RolesPermission>();

            CreateMap<Setup, SetupDTO>();
            CreateMap<SetupDTO, Setup>();
        }
    }
}
