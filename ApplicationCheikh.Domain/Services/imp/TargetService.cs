using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class TargetService : ITargetService
    {
        private ITargetRepository _targetRepository;

        public TargetService(ITargetRepository targetRepository)
        {
            _targetRepository = targetRepository;
        }

        public async Task<Target> AddTarget(Target model)
        {
            return await _targetRepository.AddTarget(model);
        }

        public async Task<bool> DeleteTarget(int IdTarget)
        {
            return await _targetRepository.DeleteTarget(IdTarget);
        }

        public async Task<List<Target>> GetTargetsAsync()
        {
            return await _targetRepository.GetTargetsAsync();
        }

        public async Task<Target> UpdateTarget(int Idtarget, Target model)
        {
            return await _targetRepository.UpdateTarget(Idtarget, model);
        }
    }
}
