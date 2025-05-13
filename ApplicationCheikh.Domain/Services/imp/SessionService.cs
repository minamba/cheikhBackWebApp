using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class SessionService : ISessionService
    {
        private ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<Session> AddSessions(Session model)
        {
            return await _sessionRepository.AddSessions(model);
        }

        public async Task<bool> DeleteSession(int Idsession)
        {
            return await _sessionRepository.DeleteSession(Idsession);
        }

        public async Task<List<Session>> GetSessionsAsync()
        {
            return await _sessionRepository.GetSessionsAsync();
        }

        public async Task<Session> UpdateSession(int Idtsession, Session model)
        {
            return await _sessionRepository.UpdateSession(Idtsession, model);
        }
    }
}
