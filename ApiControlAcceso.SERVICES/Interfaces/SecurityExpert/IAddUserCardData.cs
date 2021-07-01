using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IAddUserCardData
    {
        Task<bool> Add(List<UserCardNumberGroupDatumDto> model);
    }
}
