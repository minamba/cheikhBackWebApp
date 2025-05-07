using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetPayments();
        Task<Payment> UpdatePayment(int IdPayment, Payment model);
        Task<Payment> AddPayment(Payment model);
        Task<bool> DeletePayment(int IdPayment);
    }
}
