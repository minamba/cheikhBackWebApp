using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class RegistrationQueueService : IRegistrationQueueService
    {
        private IRegistrationQueueRepository _registrationQueueRepository;

        public RegistrationQueueService(IRegistrationQueueRepository registrationQueueRepository)
        {
            _registrationQueueRepository = registrationQueueRepository;
        }

        public async Task<List<RegistrationQueueViewModel>> GetRegistrationUsersQueue()
        {
            return new List<RegistrationQueueViewModel>();
        }
    }
}
