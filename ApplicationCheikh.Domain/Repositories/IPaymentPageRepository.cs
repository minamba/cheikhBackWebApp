using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Repositories
{
    public interface IPaymentPageRepository
    {
        Task<PaymentPg> GetPaymentPg();
        Task<PaymentPg> UpdatePaymentPg(int IRegistration, PaymentPg model);
    }
}
