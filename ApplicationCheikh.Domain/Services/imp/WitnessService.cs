using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class WitnessService : IWitnessService
    {
        private IWitnessRepository _witnessRepository;

        public WitnessService(IWitnessRepository witnessRepository)
        {
            _witnessRepository = witnessRepository;
        }

        public async Task<List<WitnessViewModel>> GetWitnessesAsync()
        {
            return new List<WitnessViewModel>();
        }
    }
}
