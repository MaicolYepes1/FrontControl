using ApiControlAcceso.MODELS.Loads.Mail;
using ApiControlAcceso.SERVICES.Interfaces.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControlAcceso.APIS.Controllers.SendMail
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        #region Dependencys
        private readonly IMailService _mail;
        #endregion

        #region Constructor
        public SendMailController(IMailService mail)
        {
            _mail = mail;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Send(MailLoad model)
        {
            var result = await _mail.SendEmail(model);

            if (result
                != false)
            {
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }
        #endregion
    }
}
