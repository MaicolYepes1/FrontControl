using ApiControlAcceso.SERVICES.Interfaces.Login;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace ApiControlAcceso.APIS.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        #region Dependency
        private readonly IHelperService _help;
        #endregion

        #region Constructor
        public HelperController(IHelperService helper)
        {
            _help = helper;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _help.Get();
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
