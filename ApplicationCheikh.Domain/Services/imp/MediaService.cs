using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Services.imp
{
    public class MediaService : IMediaService
    {
        private IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        public async Task<Media> AddMedia(Media model)
        {
            return await _mediaRepository.AddMedia(model);
        }

        public async Task<bool> DeleteMedia(int IdMedia)
        {
            return await _mediaRepository.DeleteMedia(IdMedia);
        }

        public async Task<List<Media>> GetMediasAsync()
        {
           return await _mediaRepository.GetMediasAsync();
        }

        public async Task<Media> UpdateMedia(int IdMedia, Media model)
        {
           return await _mediaRepository.UpdateMedia(IdMedia, model);
        }
    }
}
