using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Vueling.Common.Logic.Log;

namespace Vueling.Common.Logic.Utils
{
    public class SendMail
    {
        private readonly IVuelingLogger _log = new VuelingLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string smtp = "smtp.gmail.com";
        private static readonly string myMail = "cygmindundi@gmail.com";

        public SendMail()
        {

        }

        //Mindundi2017
        public void email_send(string error)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(myMail);
            mail.To.Add("carlos.yllana@atmira.com");
            mail.Subject = "ERROR:";
            mail.Body = error;

            /* System.Net.Mail.Attachment attachment;
             attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
             mail.Attachments.Add(attachment);
             */
            var SmtpServer = new SmtpClient
            {
                Host = smtp,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(myMail, "Mindundi2017")
            };

            try
            {
                _log.Info("Inicio Envio Correo " + System.Reflection.MethodBase.GetCurrentMethod().Name);
                SmtpServer.Send(mail);
            }
            catch (SmtpFailedRecipientsException ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
            }
            catch (Exception ex)
            {
                _log.Fatal("Error en " + System.Reflection.MethodBase.GetCurrentMethod().Name + "--> " + ex.Message);
            }
            finally
            {
                _log.Info("Final Envio Correo " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

    }
}
