using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class PaymentPageService : IPaymentPageService
    {
        private IPaymentPageRepository _paymentPageRepository;

        public PaymentPageService(IPaymentPageRepository paymentPageRepository)
        {
            _paymentPageRepository = paymentPageRepository;
        }



        public async Task<PaymentPg> GetPaymentPg()
        {
            return await _paymentPageRepository.GetPaymentPg();
        }



        public async Task<PaymentPg> UpdatePaymentPg(int id, PaymentPg model)
        {
            return await _paymentPageRepository.UpdatePaymentPg(id, model);
        }
    }
}
