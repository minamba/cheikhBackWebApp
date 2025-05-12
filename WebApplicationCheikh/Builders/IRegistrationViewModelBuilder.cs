using ApplicationCheikh.Api.ViewModels;
using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface IRegistrationViewModelBuilder
    {
        Task<List<RegistrationViewModel>> GetRegistration();
        Task<RegistrationViewModel> UpdateRegistration(int IRegistration, Registration model);
    }
}
