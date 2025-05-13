using ApplicationCheikh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Repositories
{
    public interface IMediaRepository
    {
        Task<List<Media>> GetMediasAsync();
        Task<Media> AddMedia(Media model);
        Task<Media> UpdateMedia(int IdMedia, Media model);
        Task<bool> DeleteMedia(int IdMedia);

    }
}
