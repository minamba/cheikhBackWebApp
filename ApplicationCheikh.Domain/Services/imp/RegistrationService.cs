using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class RegistrationService : IRegistrationService
    {
        private IRegistrationRepository _registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }


        public async Task<List<Registration>> GetRegistration()
        {
            return await _registrationRepository.GetRegistration();
        }

        public async Task<Registration> UpdateRegistration(int IRegistration, Registration model)
        {
            return await _registrationRepository.UpdateRegistration(IRegistration,model);
        }
    }
}
