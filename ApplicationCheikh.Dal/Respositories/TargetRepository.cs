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
    public class TargetRepository : ITargetRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public TargetRepository()
        {
            _context = new MiaDatabaseContext();
        }

        public async Task<List<Target>> GetTargetsAsync()
        {
            return await _context.Targets.ToListAsync();
        }


        public async Task<Target> AddTarget(Target model)
        {
            var newTarget = new Target
            {
                Detail = model.Detail,
                IdSeminaire = model.IdSeminaire,
                Title = model.Title,
            };

            _context.Targets.Add(newTarget);
            _context.SaveChanges();


            return newTarget;
        }

        public async Task<Target> UpdateTarget(int Idtarget, Target model)
        {
            var targetToUpdate = await _context.Targets.FirstOrDefaultAsync(u => u.Id == Idtarget);

            if (targetToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.Title != null) targetToUpdate.Title = model.Title;
            if (model.Detail != null) targetToUpdate.Detail = model.Detail;
            if (model.IdSeminaire != null) targetToUpdate.IdSeminaire = model.IdSeminaire;

            await _context.SaveChangesAsync();

            return targetToUpdate;

        }


        public async Task<bool> DeleteTarget(int IdTarget)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var targetToDelete = await _context.Targets.FirstOrDefaultAsync(u => u.Id == IdTarget);

            if (targetToDelete == null)
                return false; // ou throw une exception;


            _context.Targets.Remove(targetToDelete);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
