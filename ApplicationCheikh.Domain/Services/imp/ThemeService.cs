using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class ThemeService : IThemeService
    {
        private IThemeRepository _themeRepository;

        public ThemeService(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }

        public async Task<Theme> AddTheme(Theme model)
        {
            return await _themeRepository.AddTheme(model);
        }

        public async Task<bool> DeleteTheme(int IdTheme)
        {
            return await _themeRepository.DeleteTheme(IdTheme);
        }

        public async Task<List<Theme>> GetThemesAsync()
        {
            return await _themeRepository.GetThemesAsync();
        }

        public async Task<Theme> UpdateTheme(int Idtheme, Theme model)
        {
            return await _themeRepository.UpdateTheme(Idtheme, model);
        }
    }
}
