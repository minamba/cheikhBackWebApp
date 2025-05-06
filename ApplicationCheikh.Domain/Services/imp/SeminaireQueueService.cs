using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class SeminaireQueueService : ISeminaireQueueRepository
    {
        private ISeminaireQueueRepository _seminaireQueueRepository;

        public SeminaireQueueService(ISeminaireQueueRepository seminaireQueueRepository)
        {
            _seminaireQueueRepository = seminaireQueueRepository;
        }

        public async Task<List<SeminaireQueueViewModel>> GetSeminaireUsersQueue()
        {
            return new List<SeminaireQueueViewModel>();
        }
    }
}
