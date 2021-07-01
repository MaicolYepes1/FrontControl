using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.SERVICES.Interfaces.Visitantes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControlAcceso.APIS.Controllers.Visitantes
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        #region Dependency
        private readonly IVehiculosService _vehiculo;
        #endregion

        #region Constructor
        public VehicleController(IVehiculosService vehiculo)
        {
            _vehiculo = vehiculo;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Add(VehiclesDto model)
        {
            var result = await _vehiculo.InsertOrUpdate(model);
            return Ok(result);
        }
        #endregion
    }
}
