using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Loads.SecurityExpert;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetCustomFieldList
    {
        Task<List<CustomFieldListGroupDatumDto>> GetListCustomFields(CustomFieldsLoad model);
    }
}
