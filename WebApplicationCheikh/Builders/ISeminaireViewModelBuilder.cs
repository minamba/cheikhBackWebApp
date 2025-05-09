using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface ISeminaireViewModelBuilder
    {
        Task<SeminaireViewModel> AddSeminaire(Seminaire model);
        Task<bool> DeleteSeminaire(int IdSeminaire);
        Task<List<SeminaireViewModel>> GetSeminaires();
        Task<SeminaireViewModel> UpdateSeminaire(int IdSeminaire, Seminaire model);
    }
}
