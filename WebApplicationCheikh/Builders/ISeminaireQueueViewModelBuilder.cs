using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface ISeminaireQueueViewModelBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<SeminaireQueueViewModel>> GetSeminaireUsersQueue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<SeminaireQueueViewModel> UpdateSeminaireUserQueue(int IdUser, SeminaireQueue model);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<SeminaireQueueViewModel> AddSeminaireUserQueue(SeminaireQueue model);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        Task<bool> DeleteSeminaireUserQueue(int IdUser);
    }
}
