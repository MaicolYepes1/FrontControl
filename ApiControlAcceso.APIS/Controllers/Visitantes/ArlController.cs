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
    public class ArlController : ControllerBase
    {
        #region Dependency
        private readonly IArlService _arl;
        #endregion

        #region Constructor
        public ArlController(IArlService arl)
        {
            _arl = arl;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Add(ArlDto model)
        {
            var result = await _arl.InsertOrUpdate(model);
            return Ok(result);
        }
        #endregion
    }
}
