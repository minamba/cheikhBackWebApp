using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builder.impl
{
    public class RegistrationQueueViewModelBuilder : IRegistrationQueueViewModelBuilder
    {
        private IRegistrationQueueService _registrationQueueService;
        private IMapper _mapper;


        public RegistrationQueueViewModelBuilder(IRegistrationQueueService registrationQueueService, IMapper mapper)
        {
            _registrationQueueService = registrationQueueService;
            _mapper = mapper;
        }

        public async Task<RegistrationQueueViewModel> AddRegistrationUserQueue(RegistrationQueue model)
        {
            var registrationToAdd = await _registrationQueueService.AddRegistrationUserQueue(model);

            var result = _mapper.Map<RegistrationQueueViewModel>(registrationToAdd);

            return result;
        }

        public async Task<bool> DeleteRegistrationUserQueue(int IdUser)
        {
            return await _registrationQueueService.DeleteRegistrationUserQueue(IdUser);
        }

        public async Task<List<RegistrationQueueViewModel>> GetRegistrationUsersQueue()
        {
            var registrationList = await _registrationQueueService.GetRegistrationUsersQueue();

            var result = _mapper.Map<List<RegistrationQueueViewModel>>(registrationList);

            return result;
        }

        public async Task<RegistrationQueueViewModel> UpdateRegistrationUserQueue(int IdUser, RegistrationQueue model)
        {
            var userToUpdate = await _registrationQueueService.UpdateRegistrationUserQueue(IdUser,model);

            var result = _mapper.Map<RegistrationQueueViewModel>(userToUpdate);

            return result;
        }
    }
}
