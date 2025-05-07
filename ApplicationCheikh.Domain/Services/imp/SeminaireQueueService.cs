using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class SeminaireQueueService : ISeminaireQueueService
    {
        private ISeminaireQueueRepository _seminaireQueueRepository;

        public SeminaireQueueService(ISeminaireQueueRepository seminaireQueueRepository)
        {
            _seminaireQueueRepository = seminaireQueueRepository;
        }

        public async Task<SeminaireQueue> AddSeminaireUserQueue(SeminaireQueue model)
        {
            return await _seminaireQueueRepository.AddSeminaireUserQueue(model);
        }

        public async Task<bool> DeleteSeminaireUserQueue(int IdUser)
        {
            return await _seminaireQueueRepository.DeleteSeminaireUserQueue(IdUser);
        }

        public async Task<List<SeminaireQueue>> GetSeminaireUsersQueue()
        {
            return await _seminaireQueueRepository.GetSeminaireUsersQueue();
        }

        public async Task<SeminaireQueue> UpdateSeminaireUserQueue(int IdUser, SeminaireQueue model)
        {
            return await _seminaireQueueRepository.UpdateSeminaireUserQueue(IdUser, model);
        }
    }
}
