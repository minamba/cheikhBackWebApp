using ApplicationCheikh.Api.ViewModels;
using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface IPaymentPageViewModelBuilder
    {
        Task<PaymentPageViewModel> GetPaymentPg();
        Task<PaymentPageViewModel> UpdatePaymentPg(int IRegistration, PaymentPg model);
    }
}
