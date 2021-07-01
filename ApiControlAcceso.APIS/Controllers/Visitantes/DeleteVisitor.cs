using ApiControlAcceso.MODELS.Loads.Visitantes;
using ApiControlAcceso.SERVICES.Interfaces.Visitantes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControlAcceso.APIS.Controllers.Visitantes
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteVisitor : ControllerBase
    {
        #region Dependencys
        private readonly IVisitantesService _visitor;
        #endregion

        #region Constructor
        public DeleteVisitor(IVisitantesService visitor)
        {
            _visitor = visitor;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Delete(GetInfoLoad model)
        {
            var result = await _visitor.Delete(model);
            return Ok(result);
        }
        #endregion
    }
}
