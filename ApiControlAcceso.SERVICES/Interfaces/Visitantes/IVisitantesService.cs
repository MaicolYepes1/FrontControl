using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.MODELS.Loads.Visitantes;
using ApiControlAcceso.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.Visitantes
{
    public interface IVisitantesService
    {
        Task<List<VisitanteDto>> Get();
        Task<bool> InsertOrUpdate(VisitanteLoad visitante);
        Task<VisitanteDto> GetInfo(GetInfoLoad model);
        Task<bool> Delete(GetInfoLoad model);
        Task<bool> AccessState(GetInfoLoad model);
    }
}
