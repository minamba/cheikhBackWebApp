using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class PaymentViewModelBuilder : IPaymentViewModelBuilder
    {
        private IPaymentService _paymentService;
        private ISeminaireService _seminaireService;
        private IMapper _mapper;


        public PaymentViewModelBuilder(IPaymentService paymentService, ISeminaireService seminaireService, IMapper mapper)
        {
            _paymentService = paymentService;
            _seminaireService = seminaireService;
            _mapper = mapper;
        }

        public async Task<PaymentViewModel> AddPayment(Payment model)
        {
            var paymentToAdd = await _paymentService.AddPayment(model);

            var result = _mapper.Map<PaymentViewModel>(paymentToAdd);

            return result;
        }

        public async Task<bool> DeletePayment(int IdPayment)
        {
            return await _paymentService.DeletePayment(IdPayment);
        }

        public async Task<List<PaymentViewModel>> GetPayments()
        {
            var paymentList = await _paymentService.GetPayments();
            var seminaires = await _seminaireService.GetSeminaires();

            var result = _mapper.Map<List<PaymentViewModel>>(paymentList);

            foreach(var r in result)
            {
                var payemnt = paymentList.FirstOrDefault(x => x.Id == r.Id);
                var seminaire = seminaires.FirstOrDefault(x => x.Id == payemnt.IdSeminaire);

                var seminaireVM = new SeminaireViewModel { 
                    Id = r.Id,
                    Title = seminaire.Title,
                    Active = seminaire.Active,
                    Amount = seminaire.Amount,
                    Banner = new ImageVIewModel(),
                    Graphic = new ImageVIewModel(),
                    Video  = new MediaViewModel()
                };

                r.Seminaire = seminaireVM;
            }

            return result;
        }

        public async Task<PaymentViewModel> UpdatePayment(int IdPayment, Payment model)
        {
            var paymentToUpdate = await _paymentService.UpdatePayment(IdPayment, model);

            var result = _mapper.Map<PaymentViewModel>(paymentToUpdate);

            return result;
        }
    }
}
