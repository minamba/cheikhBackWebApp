using ApplicationCheikh.Api.ViewModels;
using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class CloseRegistrationViewModelBuilder : ICloseRegistrationViewModelBuilder
    {

        private ICloseRegistrationService _closeregistrationService;
        private IImageViewModelBuilder _imageViewModelBuilder;
        private IMapper _mapper;

        public CloseRegistrationViewModelBuilder( ICloseRegistrationService closeregistrationService, IImageViewModelBuilder imageViewModelBuilder, IMapper mapper)
        {
            _closeregistrationService = closeregistrationService;
            _imageViewModelBuilder = imageViewModelBuilder;
            _mapper = mapper;
        }


        public async Task<CloseRegistrationViewModel> GetCloseRegistration()
        {
 
            var registrations = await _closeregistrationService.GetCloseRegistration();

            if (registrations != null)
            {
                var imagesVM = await _imageViewModelBuilder.GetImagesAsync();

                var result = _mapper.Map<CloseRegistrationViewModel>(registrations);



                var imageVM = imagesVM.FirstOrDefault(x => x.Id == registrations.IdBanner);

                if (imageVM != null)
                    result.Banner = imageVM;


                return result;
            }
            else
                return new CloseRegistrationViewModel();
        }


        public async Task<CloseRegistrationViewModel> UpdateCloseRegistration(int IRegistration, CloseRegistration model)
        {
            var registrationToUpdate = await _closeregistrationService.UpdateCloseRegistration(IRegistration, model);

            var result = _mapper.Map<CloseRegistrationViewModel>(registrationToUpdate);

            return result;
        }

    }
}
