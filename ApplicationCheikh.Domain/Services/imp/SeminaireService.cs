using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class SeminaireService : ISeminaireService
    {
        private ISeminaireRepository _seminaireRepository;

        public SeminaireService(ISeminaireRepository seminaireRepository)
        {
            _seminaireRepository = seminaireRepository;
        }

        public async Task<Seminaire> AddSeminaire(Seminaire model)
        {
            return await _seminaireRepository.AddSeminaire(model);
        }

        public async Task<bool> DeleteSeminaire(int IdSeminaire)
        {
            return await _seminaireRepository.DeleteSeminaire(IdSeminaire);
        }


        public async Task<List<Seminaire>> GetSeminaires()
        {
            return await _seminaireRepository.GetSeminaires();
        }

        public async Task<Seminaire> UpdateSeminaire(int IdSeminaire, Seminaire model)
        {
            return await _seminaireRepository.UpdateSeminaire(IdSeminaire, model);
        }
    }
}
