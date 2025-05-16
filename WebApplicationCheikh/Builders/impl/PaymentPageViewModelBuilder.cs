using ApplicationCheikh.Api.ViewModels;
using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class PaymentPageViewModelBuilder : IPaymentPageViewModelBuilder
    {
        private IPaymentPageService _paymentPageService;
        private IImageViewModelBuilder _imageViewModelBuilder;
        private IMapper _mapper;



        public PaymentPageViewModelBuilder(IPaymentPageService paymentPageService, IImageViewModelBuilder imageViewModelBuilder, IMapper mapper)
        {
            _paymentPageService = paymentPageService;
            _imageViewModelBuilder = imageViewModelBuilder;
            _mapper = mapper;
        }

        public async Task<PaymentPageViewModel> GetPaymentPg()
        {
            var payment = await _paymentPageService.GetPaymentPg();

            if (payment != null)
            {
                var imagesVM = await _imageViewModelBuilder.GetImagesAsync();

                var result = _mapper.Map<PaymentPageViewModel>(payment);



                var imageVM = imagesVM.FirstOrDefault(x => x.Id == payment.IdBanner);

                if (imageVM != null)
                    result.Banner = imageVM;


                return result;
            }
            else
                return new PaymentPageViewModel();
        }

        public async Task<PaymentPageViewModel> UpdatePaymentPg(int id, PaymentPg model)
        {
            var paymentToUpdate = await _paymentPageService.UpdatePaymentPg(id, model);

            var result = _mapper.Map<PaymentPageViewModel>(paymentToUpdate);

            return result;
        }



    }
}
