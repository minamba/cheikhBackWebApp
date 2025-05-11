using ApplicationCheikh.Api.Requests;

namespace ApplicationCheikh.Api.Builders
{
    public interface IMailViewModelBuilder
    {
        Task<string> SendMailRegistration(string recipient);
        Task<string> SendMailGroupRegistration(List<string> recipients);

        Task<string> SendMailPayment(PaymentRequest recipient);
        Task<string> SendMailGroupPayment(PaymentGroupRequest recipients);

        Task<string> SendMailSeminaire(MailRequest recipient);
        Task<string> SendMailGroupSeminaire(MailGroupRequest recipients);
    }
}
