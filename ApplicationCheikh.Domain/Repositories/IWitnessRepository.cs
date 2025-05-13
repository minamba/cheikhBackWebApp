using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Repositories
{
    public interface IWitnessRepository
    {
        Task<List<Witness>> GetWitnessAsync();
        Task<Witness> AddWitness(Witness model);
        Task<Witness> UpdateWitness(int IdWitness, Witness model);
        Task<bool> DeleteWitness(int IdWitness);
    }
}
