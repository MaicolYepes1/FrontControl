using ApiControlAcceso.MODELS.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IRecordGroup
    {
        Task<List<RecordGroupsDto>> Get();
    }
}
