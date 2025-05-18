using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services
{
    public interface ICloseRegistrationService
    {
        Task<CloseRegistration> GetCloseRegistration();
        Task<CloseRegistration> UpdateCloseRegistration(int IRegistration, CloseRegistration model);
    }
}
