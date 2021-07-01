using ApiControlAcceso.MODELS.Models;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControlAcceso.APIS.Controllers.SeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomFielUserController : ControllerBase
    {
        #region Dependency
        private readonly IAddCustomFieldsUser _add;
        #endregion

        #region Constructor
        public AddCustomFielUserController(IAddCustomFieldsUser add)
        {
            _add = add;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Add(List<UserCustomFieldGroupDatum> model)
        {
            try
            {
                var res = await _add.Add(model[0]);
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
