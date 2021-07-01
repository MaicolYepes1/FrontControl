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
    public class GetRecordGroupController : ControllerBase
    {
        #region Dependency
        private readonly IRecordGroup _record;
        #endregion

        #region Constructor
        public GetRecordGroupController(IRecordGroup record)
        {
            _record = record;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _record.Get();
            return Ok(result);
        }
        #endregion
    }
}
