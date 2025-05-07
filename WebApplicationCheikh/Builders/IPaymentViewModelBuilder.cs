using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface IPaymentViewModelBuilder
    {
        Task<List<PaymentViewModel>> GetPayments();
        Task<PaymentViewModel> UpdatePayment(int IdPayment, Payment model);
        Task<PaymentViewModel> AddPayment(Payment model);
        Task<bool> DeletePayment(int IdPayment);
    }
}
