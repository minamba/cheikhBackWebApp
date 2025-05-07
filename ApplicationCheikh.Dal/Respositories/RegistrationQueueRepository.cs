using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApplicationCheikh.Dal.Respositories
{
    public class RegistrationQueueRepository : IRegistrationQueueRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public RegistrationQueueRepository()
        {
            _context = new MiaDatabaseContext();
        }


        public async Task<List<RegistrationQueue>> GetRegistrationUsersQueue()
        {
            return await _context.RegistrationQueues.ToListAsync();
        }


        public async Task<RegistrationQueue> AddRegistrationUserQueue(RegistrationQueue model)
        {
            var newRegistration = new RegistrationQueue
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Email = model.Email,
                Date = model.Date,
                IsContacted = model.IsContacted,
                PhoneNumber = model.PhoneNumber,
                SendedToBot = model.SendedToBot

            };

            _context.RegistrationQueues.Add(newRegistration);
            _context.SaveChanges();


            return newRegistration;

        }

        public async Task<RegistrationQueue> UpdateRegistrationUserQueue(int IdUser, RegistrationQueue model)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var userToUpdate = await _context.RegistrationQueues.FirstOrDefaultAsync(u => u.Id == IdUser);

            if (userToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.FirstName != null) userToUpdate.FirstName = model.FirstName;
            if (model.LastName != null) userToUpdate.LastName = model.LastName;
            if (model.Email != null) userToUpdate.Email = model.Email;
            if (model.PhoneNumber != null) userToUpdate.PhoneNumber = model.PhoneNumber;
            if (model.Date.HasValue) userToUpdate.Date = model.Date.Value;
            if (model.IsContacted.HasValue) userToUpdate.IsContacted = model.IsContacted.Value;
            if (model.SendedToBot.HasValue) userToUpdate.SendedToBot = model.SendedToBot.Value;

            await _context.SaveChangesAsync();

            return userToUpdate;

        }


        public async Task<bool> DeleteRegistrationUserQueue(int IdUser)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var userToDelete = await _context.RegistrationQueues.FirstOrDefaultAsync(u => u.Id == IdUser);

            if (userToDelete == null)
                return false; // ou throw une exception;


            _context.RegistrationQueues.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return true;

        }


        private async Task<RegistrationQueue> GetUserById(int IdUser)
        {
            var registrationQueueEntity = await _context.RegistrationQueues.ToListAsync();
            return registrationQueueEntity.FirstOrDefault(r => r.Id == IdUser);
        }

    }
}
