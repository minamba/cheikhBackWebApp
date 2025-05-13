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
    public class MediaRepository : IMediaRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public MediaRepository()
        {
            _context = new MiaDatabaseContext();
        }

        public async Task<List<Media>> GetMediasAsync()
        {
            return await _context.Media.ToListAsync();
        }


        public async Task<Media> AddMedia(Media model)
        {
            var newMedia = new Media
            {
                Url = model.Url,
                Type = model.Type,
                Title = model.Title,
            };

            _context.Media.Add(newMedia);
            _context.SaveChanges();


            return newMedia;
        }

        public async Task<Media> UpdateMedia(int IdMedia, Media model)
        {
            var MediaToUpdate = await _context.Media.FirstOrDefaultAsync(u => u.Id == IdMedia);

            if (MediaToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.Title != null) MediaToUpdate.Title = model.Title;
            if (model.Url != null) MediaToUpdate.Url = model.Url;
            if (model.Type != null) MediaToUpdate.Type = model.Type;

            await _context.SaveChangesAsync();

            return MediaToUpdate;

        }


        public async Task<bool> DeleteMedia(int IdMedia)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var MediaToDelete = await _context.Media.FirstOrDefaultAsync(u => u.Id == IdMedia);

            if (MediaToDelete == null)
                return false; // ou throw une exception;


            _context.Media.Remove(MediaToDelete);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
