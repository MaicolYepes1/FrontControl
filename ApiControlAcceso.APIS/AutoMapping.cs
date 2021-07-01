using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Loads.SecurityExpert;
using ApiControlAcceso.MODELS.Loads.Visitantes;
using ApiControlAcceso.MODELS.Models;
using AutoMapper;

namespace ApiControlAcceso.APIS
{
    public class AutoMapping : Profile
    {
        #region Constructor
        public AutoMapping()
        {
            CreateMap<VisitanteLoad, Visitante>();
            CreateMap<EquipoDto, Equipo>();
            CreateMap<VehiclesDto, VehiculosVisitante>();
            CreateMap<ArlDto, Arl>();
            CreateMap<User, UserDto>();
            CreateMap<IncidenteDto, Incidente>();
            CreateMap<CustomFieldListGroupDatum, CustomFieldListGroupDatumDto>();
            CreateMap<RecordGroup, RecordGroupsDto>();
            CreateMap<UserCardNumberGroupDatumDto, UserCardNumberGroupDatum>();
            CreateMap<UserCardNumberGroupDatum, UserCardNumberGroupDatumDto>();            
            CreateMap<UserAccessLevelGroupDatum, UserAccessLevelGroupDatumDto>();
            CreateMap<UserCustomFieldGroupDatum, UserCustomFieldGroupDatumDto>();
            CreateMap<UserAccessLevelGroupDatumDto, UserAccessLevelGroupDatum>();
            CreateMap<UsserInfoDto, User>();
            CreateMap<Site, SiteDto>();
            CreateMap<CustomFields, CustomFieldsDto>();
            CreateMap<AccessLevel, AccessLevelsDto>();
            CreateMap<UsserInfoDto, User>();
            CreateMap<AccessLevel, LevelsID>();
        }
        #endregion
    }
}
