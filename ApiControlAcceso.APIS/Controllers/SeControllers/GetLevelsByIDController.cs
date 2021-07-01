using ApiControlAcceso.MODELS.Loads.SecurityExpert;
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
    public class GetLevelsByIDController : ControllerBase
    {
        #region Dependency
        private readonly IGetLevelsByID _get;
        #endregion

        #region Constructor
        public GetLevelsByIDController(IGetLevelsByID get)
        {
            _get = get;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Get(List<LevelsID> model)
        {
            try
            {
                var res = await _get.Get(model);
                return res != null ? Ok(res) : NoContent();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
