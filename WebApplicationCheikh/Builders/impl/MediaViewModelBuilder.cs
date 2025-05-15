using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class MediaViewModelBuilder : IMediaViewModelBuilder
    {
        private IMediaService _mediaService;
        private IMapper _mapper;


        public MediaViewModelBuilder(IMediaService mediaService, IMapper mapper)
        {
            _mediaService = mediaService;
            _mapper = mapper;
        }

        public async Task<MediaViewModel> AddMedia(Media model)
        {
            var result =  await _mediaService.AddMedia(model);

            return new MediaViewModel
            {
                Id = result.Id,
                Title = result.Title,
                Type = result.Type,
                Url = result.Url,
            };
        }

        public async Task<bool> DeleteMedia(int IdMedia)
        {
            return await _mediaService.DeleteMedia(IdMedia);
        }

        public async Task<List<MediaViewModel>> GetMediasAsync()
        {
            var medias = await _mediaService.GetMediasAsync();
            var list = new List<MediaViewModel>();

            foreach (var item in medias)
            {
                var vm = new MediaViewModel
                {
                    Url = item.Url,
                    Type = item.Type,
                    Id = item.Id,
                    Title = item.Title,
                };

                list.Add(vm);
            }

            return list;
        }

        public async Task<MediaViewModel> UpdateMedia(int IdMedia, Media model)
        {
            var mediaToUpdate = await _mediaService.UpdateMedia(model.Id, model);

            var result = _mapper.Map<MediaViewModel>(mediaToUpdate);

            return result;
        }
    }
}
