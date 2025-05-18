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
    public class CloseRegistrationRepository : ICloseRegistrationRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public CloseRegistrationRepository()
        {
            _context = new MiaDatabaseContext();
        }


        public async Task<CloseRegistration> GetCloseRegistration()
        {
            var result = await _context.CloseRegistrations.FirstOrDefaultAsync();

            return result;
        }

        public async Task<CloseRegistration> UpdateCloseRegistration(int IRegistration, CloseRegistration model)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var registrationToUpdate = await _context.CloseRegistrations.FirstOrDefaultAsync(u => u.Id == IRegistration);

            if (registrationToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.Title != null) registrationToUpdate.Title = model.Title;
            if (model.IdBanner != null) registrationToUpdate.IdBanner = model.IdBanner;

            await _context.SaveChangesAsync();

            return registrationToUpdate;
        }
    }
}
