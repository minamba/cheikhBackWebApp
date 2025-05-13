using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface ISessionViewModelBuilder
    {
        Task<List<SessionViewModel>> GetSessionsAsync();
        Task<SessionViewModel> UpdateSession(int Idtsession, Session model);
        Task<bool> DeleteSession(int Idsession);
        Task<SessionViewModel> AddSessions(Session model);
    }
}
