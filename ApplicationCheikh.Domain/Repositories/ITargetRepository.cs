using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Repositories
{
    public interface ITargetRepository
    {
        Task<List<Target>> GetTargetsAsync();
        Task<Target> UpdateTarget(int Idtarget, Target model);
        Task<bool> DeleteTarget(int IdTarget);
        Task<Target> AddTarget(Target model);

    }
}
