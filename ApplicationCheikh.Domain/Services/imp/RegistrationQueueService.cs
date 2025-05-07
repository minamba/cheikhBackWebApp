using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using AutoMapper;
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

        public async Task<RegistrationQueue> AddRegistrationUserQueue(RegistrationQueue model)
        {
            return await _registrationQueueRepository.AddRegistrationUserQueue(model);
        }

        public async Task<bool> DeleteRegistrationUserQueue(int IdUser)
        {
            return await _registrationQueueRepository.DeleteRegistrationUserQueue(IdUser);
        }

        public async Task<List<RegistrationQueue>> GetRegistrationUsersQueue()
        {
            return await _registrationQueueRepository.GetRegistrationUsersQueue();
        }

        public async Task<RegistrationQueue> UpdateRegistrationUserQueue(int IdUser, RegistrationQueue model)
        {
           return await _registrationQueueRepository.UpdateRegistrationUserQueue(IdUser, model);
        }
    }
}
