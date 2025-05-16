using ApplicationCheikh.Api.Builders.impl;
using ApplicationCheikh.Api.ViewModels;
using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface ICloseRegistrationViewModelBuilder
    {
        Task<CloseRegistrationViewModel> GetCloseRegistration();
        Task<CloseRegistrationViewModel> UpdateCloseRegistration(int IRegistration, CloseRegistration model);
    }
}
