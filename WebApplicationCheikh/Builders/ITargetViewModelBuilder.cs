using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface ITargetViewModelBuilder
    {
        Task<List<TargetViewModel>> GetTargetsAsync();
        Task<TargetViewModel> UpdateTarget(int Idtarget, Target model);
        Task<bool> DeleteTarget(int IdTarget);
        Task<TargetViewModel> AddTarget(Target model);
    }
}
