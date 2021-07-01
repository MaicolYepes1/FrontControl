using ApiControlAcceso.MODELS.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetAllPeople
    {
        Task<List<UserDto>> GetAllPeopleSe();
    }
}
