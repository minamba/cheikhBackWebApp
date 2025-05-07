using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> AddPayment(Payment model)
        {
            return await _paymentRepository.AddPayment(model);
        }

        public async Task<bool> DeletePayment(int IdPayment)
        {
            return await _paymentRepository.DeletePayment(IdPayment);
        }

        public async Task<List<Payment>> GetPayments()
        {
            return await _paymentRepository.GetPayments();
        }

 
        public async Task<Payment> UpdatePayment(int IdPayment, Payment model)
        {
            return await _paymentRepository.UpdatePayment(IdPayment, model);
        }
    }
}
