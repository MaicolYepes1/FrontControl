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
    public class GetSiteIDController : ControllerBase
    {
        #region Dependency
        private readonly IGetSiteIDService _site;
        #endregion

        #region Constructor
        public GetSiteIDController(IGetSiteIDService site)
        {
            _site = site;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _site.GetSiteID();
                return result != null ? Ok(result) : (IActionResult)NoContent();;
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        #endregion
    }
}
