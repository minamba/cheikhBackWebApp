using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class SeminaireViewModelBuilder : ISeminaireViewModelBuilder
    {

        private ISeminaireService _seminaireService;

        public SeminaireViewModelBuilder(ISeminaireService seminaireService)
        {
            _seminaireService = seminaireService;
        }
        public async Task<SeminaireViewModel> AddSeminaire(Seminaire model)
        {
            var sem = await _seminaireService.AddSeminaire(model);

            var result = new SeminaireViewModel
            {
                Title = model.Title,
                Amount = model.Amount,
                Banner = new ImageVIewModel(),
                Graphic = new ImageVIewModel(),
                Video = new MediaViewModel(),
                Active = model.Active,
                
            };

            return result;
        }

        public async Task<bool> DeleteSeminaire(int IdSeminaire)
        {
            return await _seminaireService.DeleteSeminaire(IdSeminaire);
        }

        public async Task<List<SeminaireViewModel>> GetSeminaires()
        {
            var sems = await _seminaireService.GetSeminaires();

            var result = new List<SeminaireViewModel>();

            foreach (var se in sems)
            {
                var seminaire = new SeminaireViewModel
                {
                    Title = se.Title,
                    Amount = se.Amount,
                    Banner = new ImageVIewModel(),
                    Graphic = new ImageVIewModel(),
                    Video = new MediaViewModel(),
                    Active = se.Active,
                };

                result.Add(seminaire);
            }

            return result;
        }

        public async Task<SeminaireViewModel> UpdateSeminaire(int IdSeminaire, Seminaire model)
        {
            var sem = await _seminaireService.UpdateSeminaire(IdSeminaire, model);

            var result = new SeminaireViewModel
            {
                Title = model.Title,
                Amount = model.Amount,
                Banner = new ImageVIewModel(),
                Graphic = new ImageVIewModel(),
                Video = new MediaViewModel(),
                Active = model.Active,

            };

            return result;
        }
    }
}
