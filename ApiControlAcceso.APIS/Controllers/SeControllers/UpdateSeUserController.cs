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
    public class UpdateSeUserController : ControllerBase
    {
        #region Dependency
        private readonly IUpdateUserSe _update;
        #endregion

        #region Constructor
        public UpdateSeUserController(IUpdateUserSe update)
        {
            _update = update;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Update(SeInfoDto model)
        {
            var result = await  _update.Update(model);
            return Ok(result);        
        }
        #endregion
    }
}
