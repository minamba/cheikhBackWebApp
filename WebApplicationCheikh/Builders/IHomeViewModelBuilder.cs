using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface IHomeViewModelBuilder
    {
        Task<HomeViewModel> GetHomeAsync();
        Task<HomeViewModel> UpdateHome(int IdHome, Home model);
    }
}
