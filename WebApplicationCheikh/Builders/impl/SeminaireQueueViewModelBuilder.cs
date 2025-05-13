using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class SeminaireQueueViewModelBuilder : ISeminaireQueueViewModelBuilder
    {
        private ISeminaireQueueService _seminaireQueueService;
        private ISeminaireService _seminaireService;
        private IMapper _mapper;


        public SeminaireQueueViewModelBuilder(ISeminaireQueueService seminaireQueueService, ISeminaireService seminaireService, IMapper mapper)
        {
            _seminaireQueueService = seminaireQueueService;
            _seminaireService = seminaireService;
            _mapper = mapper;
        }

        public async Task<(SeminaireQueueViewModel list, string error)> AddSeminaireUserQueue(SeminaireQueue model)
        {

            if (await VerifUserExist(model) == false)
            {

                var seminaireToAdd = await _seminaireQueueService.AddSeminaireUserQueue(model);

                var result = _mapper.Map<SeminaireQueueViewModel>(seminaireToAdd);

                return (result, null);
            }
            else
            {
                return (null, "Cet utilisateur est deja enregistré !");
            }
        }

        public async Task<bool> DeleteSeminaireUserQueue(int IdUser)
        {
            return await _seminaireQueueService.DeleteSeminaireUserQueue(IdUser);
        }

        public async Task<List<SeminaireQueueViewModel>> GetSeminaireUsersQueue()
        {
            var seminaireUserList = await _seminaireQueueService.GetSeminaireUsersQueue();
            var seminaires = await _seminaireService.GetSeminaires();

            var result = _mapper.Map<List<SeminaireQueueViewModel>>(seminaireUserList);

            foreach (var r in result)
            {
                var seminaireUser = seminaireUserList.FirstOrDefault(x => x.Id == r.Id);

                if (seminaireUser.IdSeminaire != null)
                {
                    var seminaire = seminaires.FirstOrDefault(x => x.Id == seminaireUser.IdSeminaire);

                    var seminaireVM = new SeminaireViewModel
                    {
                        Id = r.Id,
                        Title = seminaire.Title,
                        Active = seminaire.Active,
                        Amount = seminaire.Amount,
                        Banner = new ImageVIewModel(),
                        Graphic = new ImageVIewModel(),
                        Video = new MediaViewModel()
                    };

                    r.Seminaire = seminaireVM;
                }
                else
                    r.Seminaire = null;
            }

            return result;
        }

        public async Task<SeminaireQueueViewModel> UpdateSeminaireUserQueue(int IdUser, SeminaireQueue model)
        {
            var userToUpdate = await _seminaireQueueService.UpdateSeminaireUserQueue(IdUser, model);

            var result = _mapper.Map<SeminaireQueueViewModel>(userToUpdate);

            return result;
        }



        private async Task<bool> VerifUserExist(SeminaireQueue model)
        {
            var getuser =  _seminaireQueueService.GetSeminaireUsersQueue().Result.FirstOrDefault(x => x.Email == model.Email);

            if (getuser != null)
            {
                return true;
            }   
            return false;
        }
    }
}
