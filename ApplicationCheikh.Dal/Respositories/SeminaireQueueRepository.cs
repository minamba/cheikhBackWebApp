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
    public class SeminaireQueueRepository : ISeminaireQueueRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public SeminaireQueueRepository()
        {
            _context = new MiaDatabaseContext();
        }

        public async Task<SeminaireQueue> AddSeminaireUserQueue(SeminaireQueue model)
        {
            var newSeminaire = new SeminaireQueue
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Email = model.Email,
                Date = model.Date,
                MailSent = model.MailSent,
                
            };

            _context.SeminaireQueues.Add(newSeminaire);
            _context.SaveChanges();


            return newSeminaire;
        }

        public async Task<bool> DeleteSeminaireUserQueue(int IdUser)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var userToDelete = await _context.SeminaireQueues.FirstOrDefaultAsync(u => u.Id == IdUser);

            if (userToDelete == null)
                return false; // ou throw une exception;


            _context.SeminaireQueues.Remove(userToDelete);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<SeminaireQueue>> GetSeminaireUsersQueue()
        {
            return await _context.SeminaireQueues.ToListAsync();
        }

        public async Task<SeminaireQueue> UpdateSeminaireUserQueue(int IdUser, SeminaireQueue model)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var userToUpdate = await _context.SeminaireQueues.FirstOrDefaultAsync(u => u.Id == IdUser);

            if (userToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.FirstName != null) userToUpdate.FirstName = model.FirstName;
            if (model.LastName != null) userToUpdate.LastName = model.LastName;
            if (model.Email != null) userToUpdate.Email = model.Email;
            if (model.Date.HasValue) userToUpdate.Date = model.Date.Value;
            if (model.MailSent.HasValue) userToUpdate.MailSent = model.MailSent.Value;

            await _context.SaveChangesAsync();

            return userToUpdate;
        }
    }
}
