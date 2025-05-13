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
    public class RegistrationRepository : IRegistrationRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public RegistrationRepository()
        {
            _context = new MiaDatabaseContext();
        }


        public async Task<List<Registration>> GetRegistration()
        {
            return await _context.Registrations.ToListAsync();
        }

        public async Task<Registration> UpdateRegistration(int IRegistration, Registration model)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var registrationToUpdate = await _context.Registrations.FirstOrDefaultAsync(u => u.Id == IRegistration);

            if (registrationToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.Title != null) registrationToUpdate.Title = model.Title;
            if (model.IsClosed != null) registrationToUpdate.IsClosed = model.IsClosed;

            await _context.SaveChangesAsync();

            return registrationToUpdate;
        }
    }
}
