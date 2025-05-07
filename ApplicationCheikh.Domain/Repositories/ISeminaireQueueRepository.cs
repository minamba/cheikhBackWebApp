using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Repositories
{
    public interface ISeminaireQueueRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<SeminaireQueue>> GetSeminaireUsersQueue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<SeminaireQueue> UpdateSeminaireUserQueue(int IdUser, SeminaireQueue model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<SeminaireQueue> AddSeminaireUserQueue(SeminaireQueue model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        Task<bool> DeleteSeminaireUserQueue(int IdUser);
    }
}
