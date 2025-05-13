using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Repositories
{
    public interface IImageRepository
    {
        Task<List<Image>> GetImagesAsync();
        Task<Image> AddImage(Image model);
        Task<Image> UpdateImage(int IdImage, Image model);
        Task<bool> DeleteImage(int IdImage);
    }
}
