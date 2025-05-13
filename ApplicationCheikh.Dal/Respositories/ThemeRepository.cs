using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Dal.Respositories
{
    public class ThemeRepository : IThemeRepository
    {

        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public ThemeRepository()
        {
            _context = new MiaDatabaseContext();
        }

        public async Task<List<Theme>> GetThemesAsync()
        {
            return await _context.Themes.ToListAsync();
        }


        public async Task<Theme> AddTheme(Theme model)
        {
            var newTheme = new Theme
            {
                Detail = model.Detail,
                IdSeminaire = model.IdSeminaire,
                Title = model.Title,
            };

            _context.Themes.Add(newTheme);
            _context.SaveChanges();


            return newTheme;
        }

        public async Task<Theme> UpdateTheme(int Idtheme, Theme model)
        {
            var themeToUpdate = await _context.Themes.FirstOrDefaultAsync(u => u.Id == Idtheme);

            if (themeToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.Title != null) themeToUpdate.Title = model.Title;
            if (model.Detail != null) themeToUpdate.Detail = model.Detail;
            if (model.IdSeminaire != null) themeToUpdate.IdSeminaire = model.IdSeminaire;

            await _context.SaveChangesAsync();

            return themeToUpdate;

        }


        public async Task<bool> DeleteTheme(int IdTheme)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var themeToDelete = await _context.Themes.FirstOrDefaultAsync(u => u.Id == IdTheme);

            if (themeToDelete == null)
                return false; // ou throw une exception;


            _context.Themes.Remove(themeToDelete);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
