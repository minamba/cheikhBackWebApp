using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Repositories
{
    public interface IRegistrationQueueRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<RegistrationQueue>> GetRegistrationUsersQueue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<RegistrationQueue> UpdateRegistrationUserQueue(int IdUser, RegistrationQueue model );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<RegistrationQueue> AddRegistrationUserQueue(RegistrationQueue model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        Task<bool> DeleteRegistrationUserQueue(int IdUser);
    }
}
