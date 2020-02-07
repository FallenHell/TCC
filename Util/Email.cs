using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Email
    {
        public bool EnviarEmail(string destinatario, string motivo, string comentario)
        {
            SmtpClient client = new SmtpClient("smtp.live.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("GerenciaRHBot@outlook.com", "GerenciaRH123");
            client.EnableSsl = true;
            client.Credentials = credentials;

            string corpo = "Informamos o seu desligamento pelo seguinte motivo:" + motivo + "\n Segue comentário do seu gestor:\n" + comentario;

            try
            {
                var mail = new MailMessage("GerenciaRHBot@outlook.com", destinatario);
                mail.Subject = "Aviso de Desligamento";
                mail.Body = corpo;

                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
