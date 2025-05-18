using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public  class CloseRegistrationService : ICloseRegistrationService
    {
        private ICloseRegistrationRepository _closeRegistrationRepository;

        public CloseRegistrationService(ICloseRegistrationRepository closeregistrationRepository)
        {
            _closeRegistrationRepository = closeregistrationRepository;
        }

        public async Task<CloseRegistration> GetCloseRegistration()
        {
            return await _closeRegistrationRepository.GetCloseRegistration();
        }

        public async Task<CloseRegistration> UpdateCloseRegistration(int IRegistration, CloseRegistration model)
        {
            return await _closeRegistrationRepository.UpdateCloseRegistration(IRegistration,model);
        }

    }
}
