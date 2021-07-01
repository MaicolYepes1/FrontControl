using ApiControlAcceso.MODELS.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IAddLevelAccess
    {
        Task<bool> Add(List<UserAccessLevelGroupDatumDto> model);
    }
}
