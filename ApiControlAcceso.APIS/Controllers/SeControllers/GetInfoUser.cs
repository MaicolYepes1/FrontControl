using ApiControlAcceso.MODELS.Constants;
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
    public class GetInfoUser : ControllerBase
    {
        #region Dependency
        private readonly IGetCustomFieldsUser _user;
        #endregion

        #region Constructor
        public GetInfoUser(IGetCustomFieldsUser user)
        {
            _user = user;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Get(Request request)
        {
            var res = await _user.GetInfo(request);
            return Ok(res);        
        }
        #endregion
    }
}
