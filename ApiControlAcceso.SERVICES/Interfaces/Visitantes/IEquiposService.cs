using ApiControlAcceso.MODELS.Dtos;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.Visitantes
{
    public interface IEquiposService
    {
        Task<bool> InsertOrUpdate(EquipoDto model);
    }
}
