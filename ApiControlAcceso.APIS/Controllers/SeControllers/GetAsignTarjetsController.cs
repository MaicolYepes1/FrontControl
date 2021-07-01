using ApiControlAcceso.MODELS.Constants;
using ApiControlAcceso.SERVICES.Interfaces.SecurityExpert;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiControlAcceso.APIS.Controllers.SeControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAsignTarjetsController : ControllerBase
    {
        #region Dependency
        private readonly IGetAsignTarjet _get;
        #endregion

        #region Constructor
        public GetAsignTarjetsController(IGetAsignTarjet get)
        {
            _get = get;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _get.Get();
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get(Request request)
        {
            try
            {
                var res = await _get.GetUsertTarjet(request);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
