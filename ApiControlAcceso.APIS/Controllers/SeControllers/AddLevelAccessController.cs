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
    public class AddLevelAccessController : ControllerBase
    {
        #region Dependency
        private readonly IAddLevelAccess _add;
        #endregion

        #region Constructor
        public AddLevelAccessController(IAddLevelAccess add)
        {
            _add = add;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Add(List<UserAccessLevelGroupDatumDto> model)
        {
            try
            {
                var res = await _add.Add(model);
                if (res)
                {
                    return Ok(res);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}
