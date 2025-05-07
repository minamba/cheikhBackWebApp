using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builder
{
    public interface IRegistrationQueueViewModelBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<RegistrationQueueViewModel>> GetRegistrationUsersQueue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<RegistrationQueueViewModel> UpdateRegistrationUserQueue(int IdUser, RegistrationQueue model);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<RegistrationQueueViewModel> AddRegistrationUserQueue(RegistrationQueue model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        Task<bool> DeleteRegistrationUserQueue(int IdUser);
    }
}
