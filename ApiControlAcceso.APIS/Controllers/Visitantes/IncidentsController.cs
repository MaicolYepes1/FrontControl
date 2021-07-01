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
    public class IncidentsController : ControllerBase
    {
        #region Dependency
        private readonly IIncidentesService _inc;
        #endregion

        #region Constructor
        public IncidentsController(IIncidentesService inc)
        {
            _inc = inc;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Add(IncidenteDto model)
        {
            var result = await _inc.InsertOrUpdate(model);
            return Ok(result);
        }
        #endregion
    }
}
