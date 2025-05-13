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

        public async Task<Witness> AddWitness(Witness model)
        {
            return await _witnessRepository.AddWitness(model);
        }

        public async Task<bool> DeleteWitness(int IdWitness)
        {
            return await _witnessRepository.DeleteWitness(IdWitness);
        }

        public async Task<List<Witness>> GetWitnessAsync()
        {
            return await _witnessRepository.GetWitnessAsync();
        }

        public async Task<List<Witness>> GetWitnessesAsync()
        {
            return await _witnessRepository.GetWitnessAsync();
        }

        public async Task<Witness> UpdateWitness(int IdWitness, Witness model)
        {
            return await _witnessRepository.UpdateWitness(IdWitness, model);
        }
    }
}
