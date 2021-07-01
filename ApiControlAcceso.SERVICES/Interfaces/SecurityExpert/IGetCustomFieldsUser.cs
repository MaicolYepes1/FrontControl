using ApiControlAcceso.MODELS.Constants;
using ApiControlAcceso.MODELS.Dtos;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetCustomFieldsUser
    {
        Task<InfoDto> GetInfo(Request request);
    }
}
