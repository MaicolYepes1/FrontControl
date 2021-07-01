using ApiControlAcceso.MODELS.Constants;
using ApiControlAcceso.MODELS.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetAsignTarjet
    {
        Task<List<string>> Get();
        Task<List<UserCardNumberGroupDatumDto>> GetUsertTarjet(Request model);
    }
}
