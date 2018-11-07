using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionResidencias.Acciones
{
   public class Enviarcorreo
    {
        public string correo;
        public string mensaje;
        public string password;
        public string subjecto;
        public void enviar() {
            using (var context = new ResidenciasEntities(new Conexion().returnconexion().ConnectionString)) {
                string emailto = correo;

                MailMessage mail = new MailMessage(context.Params.FirstOrDefault(x => x.Llave == "correo").Valor,correo);
                SmtpClient client = new SmtpClient();
                client.Port = int.Parse(context.Params.FirstOrDefault(x => x.Llave == "port").Valor);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(context.Params.FirstOrDefault(x => x.Llave == "correo").Valor, context.Params.FirstOrDefault(x => x.Llave == "password").Valor); client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = context.Params.FirstOrDefault(x => x.Llave == "host").Valor;
                mail.Subject = subjecto+ emailto;
                mail.Body = createEmailBody(emailto, password, mensaje);
                mail.IsBodyHtml = true;
                client.Send(mail);
            }

            }




            private string createEmailBody(string userName, string password, string mensaje)

        {

            string body = string.Empty;

            using (StreamReader reader = new StreamReader("~/Templates/recovery.html"))

            {

                body = reader.ReadToEnd();

            }

            body = body.Replace("{Usuario}", userName);   

            body = body.Replace("{password}", password);
            body = body.Replace("{mensaje}", mensaje);


            return body;

        }


       


    }
}
