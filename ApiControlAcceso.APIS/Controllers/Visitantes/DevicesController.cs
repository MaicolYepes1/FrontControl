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
    public class DevicesController : ControllerBase
    {
        #region Dependency
        private readonly IEquiposService _device;
        #endregion

        #region Constructor
        public DevicesController(IEquiposService device)
        {
            _device = device;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Add(EquipoDto model)
        {
            var result = await _device.InsertOrUpdate(model);
            return Ok(result);
        }
        #endregion
    }
}
