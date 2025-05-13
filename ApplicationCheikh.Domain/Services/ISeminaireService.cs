using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services
{
    public interface ISeminaireService
    {
        Task<Seminaire> AddSeminaire(Seminaire model);
        Task<bool> DeleteSeminaire(int IdSeminaire);
        Task<List<Seminaire>> GetSeminaires();
        Task<Seminaire> UpdateSeminaire(int IdSeminaire, Seminaire model);
    }
}
