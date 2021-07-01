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
    public class AddUserCardDataController : ControllerBase
    {
        #region Dependency
        private readonly IAddUserCardData _add;
        #endregion

        #region Constructor
        public AddUserCardDataController(IAddUserCardData add)
        {
            _add = add;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Add(List<UserCardNumberGroupDatumDto> model)
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
