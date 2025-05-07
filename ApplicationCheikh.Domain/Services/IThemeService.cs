using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services
{
    public interface IThemeService
    {
        Task<List<Theme>> GetThemesAsync();
    }
}
