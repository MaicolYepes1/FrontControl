using ApiControlAcceso.MODELS.Loads.Visitantes;
using ApiControlAcceso.SERVICES.Interfaces.Visitantes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiControlAcceso.APIS.Controllers.Visitantes
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitantesController : ControllerBase
    {
        #region Depedencias
        private readonly IVisitantesService _visitante;
        #endregion

        #region Contructor
        public VisitantesController(IVisitantesService visitante)
        {
            _visitante = visitante;
        }
        #endregion

        #region Metodos
        [HttpGet]
        public async Task<IActionResult> Visitantes()
        {
            var result = await _visitante.Get();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdate(VisitanteLoad model)
        {
            try
            {
                var result = await _visitante.InsertOrUpdate(model);

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
