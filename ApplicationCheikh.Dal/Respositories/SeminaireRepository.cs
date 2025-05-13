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
    public class SeminaireRepository : ISeminaireRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public SeminaireRepository()
        {
            _context = new MiaDatabaseContext();
        }

        public async Task<Seminaire> AddSeminaire(Seminaire model)
        {
            var newSeminaire = new Seminaire
            {
                Title = model.Title,
                IdBanner = model.IdBanner,
                IdMedia = model.IdMedia,
                IdImage = model.IdImage,
                Amount = model.Amount,
                Active = model.Active,
            };

            _context.Seminaires.Add(newSeminaire);
            _context.SaveChanges();


            return newSeminaire;
        }

        public async Task<bool> DeleteSeminaire(int IdSeminaire)
        {
            // On récupère le seminaire  existant (celui déjà en base)
            var seminaireToDelete =  _context.Seminaires.FirstOrDefault(u => u.Id == IdSeminaire);

            if (seminaireToDelete == null)
                return false; // ou throw une exception;


            _context.Seminaires.Remove(seminaireToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Seminaire>> GetSeminaires()
        {
            return await _context.Seminaires.ToListAsync();
        }

        public async Task<Seminaire> UpdateSeminaire(int IdSeminaire, Seminaire model)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var seminaireToUpdate = await _context.Seminaires.FirstOrDefaultAsync(u => u.Id == IdSeminaire);

            if (seminaireToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.Title != null) seminaireToUpdate.Title = model.Title;
            if (model.IdBanner != null) seminaireToUpdate.IdBanner = model.IdBanner;
            if (model.IdMedia != null) seminaireToUpdate.IdMedia = model.IdMedia;
            if (model.IdImage.HasValue) seminaireToUpdate.IdImage = model.IdImage.Value;
            if (model.Amount.HasValue) seminaireToUpdate.Amount = model.Amount.Value;
            if (model.Active.HasValue) seminaireToUpdate.Active = model.Active.Value;


            await _context.SaveChangesAsync();

            return seminaireToUpdate;
        }
    }
}
