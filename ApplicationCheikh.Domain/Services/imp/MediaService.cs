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

        public async Task<List<Media>> GetMediasAsync()
        {
            return new List<Media>();
        }
    }
}
