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
    public class SessionRepository : ISessionRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public SessionRepository()
        {
            _context = new MiaDatabaseContext();
        }

        public async Task<List<Session>> GetSessionsAsync()
        {
            return await _context.Sessions.ToListAsync();
        }


        public async Task<Session> AddSessions(Session model)
        {
            var newSessions = new Session
            {
                Detail = model.Detail,
                IdSeminaire = model.IdSeminaire,
                Title = model.Title,
            };

            _context.Sessions.Add(newSessions);
            _context.SaveChanges();


            return newSessions;
        }

        public async Task<Session> UpdateSession(int Idtsession, Session model)
        {
            var sessionToUpdate = await _context.Sessions.FirstOrDefaultAsync(u => u.Id == Idtsession);

            if (sessionToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.Title != null) sessionToUpdate.Title = model.Title;
            if (model.Detail != null) sessionToUpdate.Detail = model.Detail;
            if (model.IdSeminaire != null) sessionToUpdate.IdSeminaire = model.IdSeminaire;

            await _context.SaveChangesAsync();

            return sessionToUpdate;

        }


        public async Task<bool> DeleteSession(int Idsession)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var sessionToDelete = await _context.Sessions.FirstOrDefaultAsync(u => u.Id == Idsession);

            if (sessionToDelete == null)
                return false; // ou throw une exception;


            _context.Sessions.Remove(sessionToDelete);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
