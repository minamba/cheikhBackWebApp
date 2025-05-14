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
        private IImageViewModelBuilder _imageViewModelBuilder;
        private IMapper _mapper;

        public RegistrationViewModelBuilder(IRegistrationService registrationService, IImageViewModelBuilder imageViewModelBuilder, IMapper mapper)
        {
            _registrationService = registrationService;
            _imageViewModelBuilder = imageViewModelBuilder;
            _mapper = mapper;
        }


        public async Task<List<RegistrationViewModel>> GetRegistration()
        {
            var registrations = await _registrationService.GetRegistration();
            var imagesVM = await _imageViewModelBuilder.GetImagesAsync();

            var result = _mapper.Map<List<RegistrationViewModel>>(registrations);


            foreach (var reg in registrations)
            {
              
                foreach (var r in result)
                {
                    var imageVM = imagesVM.FirstOrDefault(x => x.Id == reg.IdBanner);
                    r.Image = imageVM;
                }
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
