using ApiControlAcceso.MODELS.Dtos;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControlAcceso.APIS.Controllers.SeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAccessLevelsController : ControllerBase
    {
        #region Dependency
        private readonly IAccessLevelsService _access;
        #endregion

        #region Constructor
        public GetAccessLevelsController(IAccessLevelsService access)
        {
            _access = access;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Get(SeLoad model)
        {
            try
            {
                var res = await _access.Get(model);
                return Ok(res);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion
    }
}
