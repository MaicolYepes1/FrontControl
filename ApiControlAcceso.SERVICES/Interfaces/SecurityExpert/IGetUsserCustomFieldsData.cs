using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Loads.Visitantes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.SecurityExpert
{
    public interface IGetUsserCustomFieldsData
    {
        Task<List<CustomFieldDto>> GetInfo(GetInfoLoad model);
    }
}
