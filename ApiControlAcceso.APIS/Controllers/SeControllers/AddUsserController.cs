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
    public class AddUsserController : ControllerBase
    {
        #region Dependency
        private readonly IAddUsserService _add;
        #endregion

        #region Constructor
        public AddUsserController(IAddUsserService add)
        {
            _add = add;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Add(UsserInfoDto model)
        {
            try
            {
                var res = await _add.Add(model);
                return res != null ? Ok(res) : (IActionResult)NoContent();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
