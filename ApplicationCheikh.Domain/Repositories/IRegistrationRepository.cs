using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Repositories
{
    public interface IRegistrationRepository
    {
        Task<List<Registration>> GetRegistration();
        Task<Registration> UpdateRegistration(int IRegistration, Registration model);
    }
}
