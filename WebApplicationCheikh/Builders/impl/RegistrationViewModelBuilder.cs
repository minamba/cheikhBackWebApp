using ApplicationCheikh.Api.ViewModels;
using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class RegistrationViewModelBuilder : IRegistrationViewModelBuilder
    {
        private IRegistrationService _registrationService;
        private IMapper _mapper;

        public RegistrationViewModelBuilder(IRegistrationService registrationService, IMapper mapper)
        {
            _registrationService = registrationService;
            _mapper = mapper;
        }


        public async Task<List<RegistrationViewModel>> GetRegistration()
        {
            var registrations = await _registrationService.GetRegistration();

            var result = _mapper.Map<List<RegistrationViewModel>>(registrations);

            foreach (var r in result)
            {
                    var seminaireVM = new RegistrationViewModel
                    {
                        Id = r.Id,
                        Title = r.Title,
                        Image = null,
                        IsClosed = r.IsClosed
                    };
            }

            return result;
        }

        public async Task<RegistrationViewModel> UpdateRegistration(int IRegistration, Registration model)
        {
            var registrationToUpdate = await _registrationService.UpdateRegistration(IRegistration, model);

            var result = _mapper.Map<RegistrationViewModel>(registrationToUpdate);

            return result;
        }
    }
}
