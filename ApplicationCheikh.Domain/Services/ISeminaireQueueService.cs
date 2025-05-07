using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services
{
    public interface ISeminaireQueueService
    {
        Task<List<SeminaireQueue>> GetSeminaireUsersQueue();
        Task<SeminaireQueue> UpdateSeminaireUserQueue(int IdUser, SeminaireQueue model);
        Task<SeminaireQueue> AddSeminaireUserQueue(SeminaireQueue model);
        Task<bool> DeleteSeminaireUserQueue(int IdUser);
    }
}
