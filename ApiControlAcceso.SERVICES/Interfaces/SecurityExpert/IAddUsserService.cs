using ApiControlAcceso.MODELS.Constants;
using ApiControlAcceso.MODELS.Dtos;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IAddUsserService
    {
        Task<Response> Add(UsserInfoDto model);
    }
}
