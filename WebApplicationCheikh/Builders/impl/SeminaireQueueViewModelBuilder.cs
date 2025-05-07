using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class SeminaireQueueViewModelBuilder : ISeminaireQueueViewModelBuilder
    {
        private ISeminaireQueueService _seminaireQueueService;
        private IMapper _mapper;


        public SeminaireQueueViewModelBuilder(ISeminaireQueueService seminaireQueueService, IMapper mapper)
        {
            _seminaireQueueService = seminaireQueueService;
            _mapper = mapper;
        }

        public async Task<SeminaireQueueViewModel> AddSeminaireUserQueue(SeminaireQueue model)
        {
            var seminaireToAdd = await _seminaireQueueService.AddSeminaireUserQueue(model);

            var result = _mapper.Map<SeminaireQueueViewModel>(seminaireToAdd);

            return result;
        }

        public async Task<bool> DeleteSeminaireUserQueue(int IdUser)
        {
            return await _seminaireQueueService.DeleteSeminaireUserQueue(IdUser);
        }

        public async Task<List<SeminaireQueueViewModel>> GetSeminaireUsersQueue()
        {
            var seminaireUserList = await _seminaireQueueService.GetSeminaireUsersQueue();

            var result = _mapper.Map<List<SeminaireQueueViewModel>>(seminaireUserList);

            return result;
        }

        public async Task<SeminaireQueueViewModel> UpdateSeminaireUserQueue(int IdUser, SeminaireQueue model)
        {
            var userToUpdate = await _seminaireQueueService.UpdateSeminaireUserQueue(IdUser, model);

            var result = _mapper.Map<SeminaireQueueViewModel>(userToUpdate);

            return result;
        }
    }
}
