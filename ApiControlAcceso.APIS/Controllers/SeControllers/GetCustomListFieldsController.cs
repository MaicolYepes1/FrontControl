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
    public class GetCustomListFieldsController : ControllerBase
    {
        #region Dependency
        private readonly IGetCustomFieldList _custom;
        #endregion

        #region Constructor
        public GetCustomListFieldsController(IGetCustomFieldList custom)
        {
            _custom = custom;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Get(CustomFieldsLoad model)
        {
            var result = await _custom.GetListCustomFields(model);
            return Ok(result);
        }
        #endregion
    }
}
