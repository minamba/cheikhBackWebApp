using ApplicationCheikh.Api.Requests;
using ApplicationCheikh.Domain.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Org.BouncyCastle.Cms;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class MailViewModelBuilder : IMailViewModelBuilder
    {
        //folders
        const string paymentFolder = "Payments";
        const string mailFolder = "Mails";
        const string registrationFolder = "Registrations";

        //templates names
        const string paymentFile = "payment-seminaire.html";
        const string mailFile = "mail-seminaire.html";
        const string registrationFile = "registration-seminaire.html";


        //subject
        private string seminaireSubject  = "Nouveau Séminaire";
        private string paymentSubject = "Confirmation d'inscription";
        private string registrationSubject = "Confirmation d'enregistrement";

        public async Task<string> SendMailPayment(PaymentRequest recipient)
        {
            paymentSubject = paymentSubject + " - " + recipient.SeminaireTitle;
            return await SendMail(recipient.Recipient, paymentFolder, paymentFile, paymentSubject);
        }

        public async Task<string> SendMailGroupPayment(PaymentGroupRequest recipients)
        {
            paymentSubject = paymentSubject + " - " + recipients.SeminaireTitle;

            foreach (var r in recipients.RecipientList)
            {
                await SendMail(r, paymentFolder, paymentFile, paymentSubject);
            }

            return "L'envoie des mails en masse s'est bien passé !";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        public async Task<string> SendMailRegistration(string recipient)
        {
           return await SendMail(recipient, registrationFolder, registrationFile, registrationSubject);
        }

        public async Task<string> SendMailGroupRegistration(List<string> recipients)
        {
            foreach (var r in recipients)
            {
                await SendMail(r,registrationFolder, registrationFile, registrationSubject);
            }

            return "L'envoie des mails en masse s'est bien passé !";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>

        public async Task<string> SendMailSeminaire(MailRequest recipient)
        {
            seminaireSubject = seminaireSubject + " - " + recipient.SeminaireTitle;
            return await SendMail(recipient.Recipient, mailFolder, mailFile, seminaireSubject);
        }

        public async Task<string> SendMailGroupSeminaire(MailGroupRequest recipients)
        {
            seminaireSubject = seminaireSubject + " - " + recipients.SeminaireTitle;

            foreach (var r in recipients.RecipientList)
            {
                await SendMail(r, mailFolder, mailFile, seminaireSubject);
            }

            return "L'envoie des mails en masse s'est bien passé !";
        }


        private async Task<string> SendMail(string recipient, string folder, string fileName, string subject)
        {
            string basePath = AppContext.BaseDirectory;
            string filePath = Path.Combine(basePath, "Templates", folder, fileName);
            string htmlContent = await File.ReadAllTextAsync(filePath);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Institut Malik Ibn Anas", "minamba.c@gmail.com"));
            message.To.Add(new MailboxAddress("", recipient));
            message.Subject = subject.ToUpper();

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlContent
            };

            message.Body = bodyBuilder.ToMessageBody();

            try
            {

                using var client = new SmtpClient();
                // Ignorer la vérification de certificat (à éviter en production)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("minamba.c@gmail.com", "lfdo fzlq pjcr sdor");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                return "Le mail à bien été envoyé";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ex.Message;
            }

        }

    }
}
