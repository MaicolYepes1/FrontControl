using ApiControlAcceso.MODELS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.Login
{
    public interface IHelperService
    {
        Task<List<Helper>> Get();
    }
}
