using SendGrid;
using System.Net;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Collections.Generic;

namespace EnvioDeEmailsComSendGrid
{
    class ServicoEmail
    {
        public static Task EnviarRedefinicaoSenha(string email, string nome, string url)
        {
            var username = Properties.Resources.userEmail;
            var pswd = Properties.Resources.userSenha;
            SendGridMessage myMessage = new SendGridMessage();

            myMessage.AddTo(email);
            myMessage.From = new MailAddress("noreply@jatanamao.com.br", "Lance Um Desafio");
            myMessage.EnableTemplateEngine("c03dd00b-eaf1-42f7-9047-5f026f42163f"); // Redefinição De Senha
            myMessage.Subject = "Lance Um Desafio - Redefinição De Senha";
            myMessage.Html = "Olá";
            myMessage.Text = "Olá";

            myMessage.AddSubstitution("[USER_NAME]", new List<string> { nome });
            myMessage.AddSubstitution("[URL_RESET]", new List<string> { url });
            var credenciais = new NetworkCredential(username, pswd);
            var transporteWeb = new Web(credenciais);


            if (transporteWeb != null)
            {
                return transporteWeb.DeliverAsync(myMessage);
            }
            else
            {
                return Task.FromResult(0);
            }

        }
    }
}
