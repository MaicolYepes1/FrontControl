using ApiControlAcceso.MODELS.Loads.SecurityExpert;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetLevelsByID
    {
        Task<List<LevelsID>> Get(List<LevelsID> model);
    }
}
