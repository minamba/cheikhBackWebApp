using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class PaymentViewModelBuilder : IPaymentViewModelBuilder
    {
        private IPaymentService _paymentService;
        private IMapper _mapper;


        public PaymentViewModelBuilder(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<PaymentViewModel> AddPayment(Payment model)
        {
            var paymentToAdd = await _paymentService.AddPayment(model);

            var result = _mapper.Map<PaymentViewModel>(paymentToAdd);

            return result;
        }

        public async Task<bool> DeletePayment(int IdPayment)
        {
            return await _paymentService.DeletePayment(IdPayment);
        }

        public async Task<List<PaymentViewModel>> GetPayments()
        {
            var paymentList = await _paymentService.GetPayments();

            var result = _mapper.Map<List<PaymentViewModel>>(paymentList);

            return result;
        }

        public async Task<PaymentViewModel> UpdatePayment(int IdPayment, Payment model)
        {
            var paymentToUpdate = await _paymentService.UpdatePayment(IdPayment, model);

            var result = _mapper.Map<PaymentViewModel>(paymentToUpdate);

            return result;
        }
    }
}
