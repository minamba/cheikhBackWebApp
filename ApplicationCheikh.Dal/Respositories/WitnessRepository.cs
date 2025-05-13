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
    public class WitnessRepository : IWitnessRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public WitnessRepository()
        {
            _context = new MiaDatabaseContext();
        }

        public async Task<List<Witness>> GetWitnessAsync()
        {
            return await _context.Witnesses.ToListAsync();
        }


        public async Task<Witness> AddWitness(Witness model)
        {
            var newWitness = new Witness
            {
                Title = model.Title,
                Description = model.Description,
                IdMedia = model.IdMedia
            };

            _context.Witnesses.Add(newWitness);
            _context.SaveChanges();


            return newWitness;
        }

        public async Task<Witness> UpdateWitness(int IdWitness, Witness model)
        {
            var WitnessToUpdate = await _context.Witnesses.FirstOrDefaultAsync(u => u.Id == IdWitness);

            if (WitnessToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.Title != null) WitnessToUpdate.Title = model.Title;
            if (model.Description != null) WitnessToUpdate.Description = model.Description;
            if (model.IdMedia != null) WitnessToUpdate.IdMedia = model.IdMedia;

            await _context.SaveChangesAsync();

            return WitnessToUpdate;

        }


        public async Task<bool> DeleteWitness(int IdWitness)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var WitnessToDelete = await _context.Witnesses.FirstOrDefaultAsync(u => u.Id == IdWitness);

            if (WitnessToDelete == null)
                return false; // ou throw une exception;


            _context.Witnesses.Remove(WitnessToDelete);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
