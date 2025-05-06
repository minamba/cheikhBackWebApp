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
        Task<List<RegistrationQueueViewModel>> GetRegistrationUsersQueue();
    }
}
