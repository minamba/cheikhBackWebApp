using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class ImageService : IImageService
    {
        private IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<Image> AddImage(Image model)
        {
            return await _imageRepository.AddImage(model);
        }

        public async Task<bool> DeleteImage(int IdImage)
        {
           return await _imageRepository.DeleteImage(IdImage);
        }

        public async Task<List<Image>> GetImagesAsync()
        {
           return await _imageRepository.GetImagesAsync();
        }

        public async Task<Image> UpdateImage(int IdImage, Image model)
        {
           return await _imageRepository.UpdateImage(IdImage, model);
        }
    }
}
