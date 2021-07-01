using ApiControlAcceso.MODELS.Loads.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Interfaces.Mail
{
    public interface IMailService
    {
        Task<bool> SendEmail(MailLoad model);
    }
}
