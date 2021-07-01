using ApiControlAcceso.MODELS.Dtos;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IUpdateUserSe
    {
        Task<bool> Update(SeInfoDto model);
    }
}
