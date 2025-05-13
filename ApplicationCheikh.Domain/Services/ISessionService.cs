using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services
{
    public interface ISessionService
    {
        Task<List<Session>> GetSessionsAsync();
        Task<Session> UpdateSession(int Idtsession, Session model);
        Task<bool> DeleteSession(int Idsession);
        Task<Session> AddSessions(Session model);
    }
}
