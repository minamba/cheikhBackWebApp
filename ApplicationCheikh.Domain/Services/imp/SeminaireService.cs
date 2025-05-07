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

        public async Task<Seminaire> GetSeminaireAsync()
        {
            return new Seminaire();
        }
    }
}
