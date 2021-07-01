using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControlAcceso.APIS.Controllers.SeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomsController : ControllerBase
    {
        #region Dependency
        private readonly IGetCustomField _custom;
        #endregion

        #region Constructor
        public CustomsController(IGetCustomField custom)
        {
            _custom = custom;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> GetInfo(List<SeLoad> model)
        {
            try
            {
                var result = await _custom.Get(model[0]);
                return Ok(result);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion
    }
}
