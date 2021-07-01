using ApiControlAcceso.MODELS.Loads.Visitantes;
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
    public class GetCustomFieldsController : ControllerBase
    {
        private readonly IGetUsserCustomFieldsData _custom;

        public GetCustomFieldsController(IGetUsserCustomFieldsData custom)
        {
            _custom = custom;
        }

        [HttpPost]
        public async Task<IActionResult> Get(GetInfoLoad model)
        {
            var result = await _custom.GetInfo(model);
            return Ok(result);
        }
    }
}
