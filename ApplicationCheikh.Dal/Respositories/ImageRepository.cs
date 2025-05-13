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
    public class ImageRepository : IImageRepository
    {
        private MiaDatabaseContext _context { get; set; }
        private readonly IMapper _mapper;

        public ImageRepository()
        {
            _context = new MiaDatabaseContext();
        }

        public async Task<List<Image>> GetImagesAsync()
        {
            return await _context.Images.ToListAsync();
        }


        public async Task<Image> AddImage(Image model)
        {
            var newImage = new Image
            {
                Url = model.Url,
                Title = model.Title,
                
            };

            _context.Images.Add(newImage);
            _context.SaveChanges();


            return newImage;
        }

        public async Task<Image> UpdateImage(int IdImage, Image model)
        {
            var ImageToUpdate = await _context.Images.FirstOrDefaultAsync(u => u.Id == IdImage);

            if (ImageToUpdate == null)
                return null; // ou throw une exception

            // On met à jour ses propriétés
            if (model.Title != null) ImageToUpdate.Title = model.Title;
            if (model.Url != null) ImageToUpdate.Url = model.Url;

            await _context.SaveChangesAsync();

            return ImageToUpdate;

        }


        public async Task<bool> DeleteImage(int IdImage)
        {
            // On récupère l'utilisateur existant (celui déjà en base)
            var ImageToDelete = await _context.Images.FirstOrDefaultAsync(u => u.Id == IdImage);

            if (ImageToDelete == null)
                return false; // ou throw une exception;


            _context.Images.Remove(ImageToDelete);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
