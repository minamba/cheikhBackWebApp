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

        public async Task<List<Image>> GetImagesAsync()
        {
            return new List<Image>();
        }

    }
}
