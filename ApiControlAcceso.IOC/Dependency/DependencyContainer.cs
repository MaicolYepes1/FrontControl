using ApiControlAcceso.INFRA.Repository.Generic;
using ApiControlAcceso.INFRA.Repository.Interfaces;
using ApiControlAcceso.MODELS.Models;
using ApiControlAcceso.SERVICES.Interfaces.Login;
using ApiControlAcceso.SERVICES.Interfaces.Mail;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using ApiControlAcceso.SERVICES.Interfaces.Visitantes;
using ApiControlAcceso.SERVICES.Services.Login;
using ApiControlAcceso.SERVICES.Services.Mail;
using ApiControlAcceso.SERVICES.Services.SecurityExpert;
using ApiControlAcceso.SERVICES.Services.Visitantes;
using Microsoft.Extensions.DependencyInjection;

namespace ApiControlAcceso.IOC.Dependency
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IVisitantesService, VisitantesService>();
            services.AddScoped<IEquiposService, EquiposService>();
            services.AddScoped<IVehiculosService, VehiculosService>();
            services.AddScoped<IArlService, ArlService>();
            services.AddScoped<IIncidentesService, IncidentesService>();
            services.AddScoped<IGetAllPeople, GetAllPeople>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IGetUsserCustomFieldsData, GetUsserCustomFieldsData>();
            services.AddScoped<IGetCustomFieldList, GetCustomFieldList>();
            services.AddScoped<IRecordGroup, GetRecordGroup>();
            services.AddScoped<IHelperService, HelperService>();
            services.AddScoped<IAddCustomFieldsUser, AddCustomFieldsUser>();
            services.AddScoped<IAddUserCardData, AddUserCardData>();
            services.AddScoped<IAddLevelAccess, AddLevelAccess>();
            services.AddScoped<IGetAsignTarjet, GetAsignTarjet>();
            services.AddScoped<IGetCustomFieldsUser, GetCustomFieldsUser>();
            services.AddScoped<IUpdateUserSe, UpdateUserSe>();
            services.AddScoped<IGetSiteIDService, GetSiteIDService>();
            services.AddScoped<IGetCustomField, GetCustomFieldService>();
            services.AddScoped<IAccessLevelsService, AccessLevelsService>();
            services.AddScoped<IAddUsserService, AddUsserService>();
            services.AddScoped<IGetLevelsByID, GetLevelsByID>();
            #endregion

            #region Repository
            services.AddScoped<IGenericRepository<Visitante>, GenericRepository<Visitante>>();
            services.AddScoped<IGenericRepository<Equipo>, GenericRepository<Equipo>>();
            services.AddScoped<IGenericRepository<VehiculosVisitante>, GenericRepository<VehiculosVisitante>>();
            services.AddScoped<IGenericRepository<Arl>, GenericRepository<Arl>>();
            services.AddScoped<IGenericRepository<Incidente>, GenericRepository<Incidente>>();
            #endregion

        }
    }
}
