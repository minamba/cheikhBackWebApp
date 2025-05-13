using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface IWitnessViewModelBuilder
    {
        Task<List<WitnessViewModel>> GetWitnessAsync();
        Task<WitnessViewModel> AddWitness(Witness model);
        Task<WitnessViewModel> UpdateWitness(int IdWitness, Witness model);
        Task<bool> DeleteWitness(int IdWitness);
    }
}
