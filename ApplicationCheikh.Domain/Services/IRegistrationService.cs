using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services
{
    public interface IRegistrationService
    {
        Task<List<Registration>> GetRegistration();
        Task<Registration> UpdateRegistration(int IRegistration, Registration model);
    }
}
