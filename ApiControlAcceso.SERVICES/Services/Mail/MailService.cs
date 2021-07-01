using ApiControlAcceso.MODELS.Loads.Mail;
using ApiControlAcceso.SERVICES.Interfaces.Mail;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ApiControlAcceso.SERVICES.Services.Mail
{
    public class MailService : IMailService
    {
        #region Constructor
        public MailService()
        {

        }
        #endregion

        #region Methods
        public async Task<bool> SendEmail(MailLoad model)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("maicolyepes1@gmail.com");
                message.To.Add(new MailAddress(model.To));
                message.Subject = model.Subject;
                message.IsBodyHtml = true;
                message.Body = model.Body;
                smtp.UseDefaultCredentials = false;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;                
                smtp.Credentials = new NetworkCredential("maicolyepes1@gmail.com", "Primerounamamada1");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
        #endregion
    }
}
