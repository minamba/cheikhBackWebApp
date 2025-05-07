using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services
{
    public interface IRegistrationQueueService
    {
        Task<List<RegistrationQueue>> GetRegistrationUsersQueue();
        Task<RegistrationQueue> UpdateRegistrationUserQueue(int IdUser, RegistrationQueue model);
        Task<RegistrationQueue> AddRegistrationUserQueue(RegistrationQueue model);
        Task<bool> DeleteRegistrationUserQueue(int IdUser);
    }
}
