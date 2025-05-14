using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class SessionViewModelBuilder : ISessionViewModelBuilder
    {
        private ISessionService _sessionService;
        private ISeminaireViewModelBuilder _seminaireService;
        private IMapper _mapper;




        public SessionViewModelBuilder(ISessionService sessionService, ISeminaireViewModelBuilder seminaireService, IMapper mapper)
        {
            _sessionService = sessionService;
            _seminaireService = seminaireService;
            _mapper = mapper;
        }

        public async Task<SessionViewModel> AddSessions(Session model)
        {
            var session = await _sessionService.AddSessions(model);

            var seminaireVm = _seminaireService.GetSeminaires().Result.FirstOrDefault(x => x.Id == model.IdSeminaire);

            var result = _mapper.Map<SessionViewModel>(session);
            result.Seminaire = seminaireVm;

            return result;
        }


        public async Task<bool> DeleteSession(int Idsession)
        {
           return await _sessionService.DeleteSession(Idsession);
        }

        public async Task<List<SessionViewModel>> GetSessionsAsync()
        {
            var sessions = _sessionService.GetSessionsAsync().Result.ToList();
            var seminaires = _seminaireService.GetSeminaires().Result.ToList();

            var list = new List<SessionViewModel>();

            var result = _mapper.Map<List<SessionViewModel>>(sessions);

            foreach (var r in result)
            {
                foreach (var t in sessions)
                {

                    if (t.Id == r.Id)
                    {
                        var SeminaireVM = _seminaireService.GetSeminaires().Result.FirstOrDefault(s => s.Id == t.IdSeminaire);

                        r.Seminaire = SeminaireVM;
                    }
                }

            }

            return result;
        }


        public async Task<SessionViewModel> UpdateSession(int Idtsession, Session model)
        {
            var session = await _sessionService.UpdateSession(Idtsession, model);

            return _mapper.Map<SessionViewModel>(session);
        }
    }
}
