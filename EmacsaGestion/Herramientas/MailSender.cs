using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Gobbi.CoreServices.Security.Principal;

namespace Herramientas
{
    public class MailSender:Page 
    {
        public static void Send(string from, string to,string[] cc, string subject,string body, bool isBodyHtml,bool hasAttach,string adjunto,string serverIp,string userCredential, string passwordCredential,string bcc)
        {
            System.Net.Mail.MailMessage Correo = new System.Net.Mail.MailMessage();
            Correo.From = new System.Net.Mail.MailAddress(from);//Si se quiere comprobar, agregar una cuenta de yahoo         
            Correo.To.Add(to);   //Si se quiere probar, poner cualquier cuenta
            for (int i = 0; i < cc.Length; i++)
            {
                Correo.CC.Add(cc[i]);
            }
            for (int i = 0; i < cc.Length; i++)
            {
                Correo.Bcc.Add(bcc);
            }
            Correo.Subject = subject;      //Completar el asunto
            Correo.Body = body;
            Correo.IsBodyHtml = isBodyHtml;
            Correo.Priority = System.Net.Mail.MailPriority.Normal;

            //Adjunto:
            if (hasAttach) {
                            System.Net.Mail.Attachment oAdjunto = new System.Net.Mail.Attachment(adjunto);
                            Correo.Attachments.Add(oAdjunto);
            }

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = serverIp;
           
            //Si se quiere probar, usar el smtp de yahoo (smtp.mail.yahoo)
            userCredential = "eduardob";
            passwordCredential = "edEMA01";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(userCredential, passwordCredential);
            //Si se quiere prbar, completar con el nombre de usuario (sin @yahoo.com ni nada) y el pass.
            smtp.Port = 25;
            
           // smtp.EnableSsl = true;
            smtp.Send(Correo);
  
        }
    }
}
