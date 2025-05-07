using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Repositories
{
    public interface IPaymentRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Payment>> GetPayments();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdPayment"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Payment> UpdatePayment(int IdPayment, Payment model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Payment> AddPayment(Payment model);

          /// <summary>
          /// 
          /// </summary>
          /// <param name="IdPayment"></param>
          /// <returns></returns>
        Task<bool> DeletePayment(int IdPayment);
    }
}
