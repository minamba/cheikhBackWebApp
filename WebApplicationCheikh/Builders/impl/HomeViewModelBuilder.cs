using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class HomeViewModelBuilder : IHomeViewModelBuilder
    {

        private IHomeService _homeService;
        private IImageService _imageService;
        private IMediaService _mediaService;
        private IMapper _mapper;

        public HomeViewModelBuilder(IHomeService homeService, IImageService imageService, IMediaService mediaService, IMapper mapper)
        {
            _homeService = homeService;
            _imageService = imageService;
            _mediaService = mediaService;
            _mapper = mapper;

        }

        public async Task<HomeViewModel> AddHome(Home model)
        {
            var hVM = new HomeViewModel()
            {
                IdBanner = model.IdBanner,
                IdMedia = model.IdMedia,
                Title = model.Title,
                IdImage = model.IdImage,
            };

            return hVM;
        }

        public async Task<HomeViewModel> GetHomeAsync()
        {
           var home = await _homeService.GetHomeAsync();
            if (home != null)
            {
                var banner = _imageService.GetImagesAsync().Result.FirstOrDefault(x => x.Id == home.IdBanner);
                var image = _imageService.GetImagesAsync().Result.FirstOrDefault(x => x.Id == home.IdImage);
                var video = _mediaService.GetMediasAsync().Result.FirstOrDefault(x => x.Id == home.IdMedia);

                var bannerVm = _mapper.Map<ImageVIewModel>(banner);
                var imageVm = _mapper.Map<ImageVIewModel>(image);
                var videoVm = _mapper.Map<MediaViewModel>(video);

                if (home != null)
                {

                    var result = new HomeViewModel()
                    {
                        Id = home.Id,
                        Title = home.Title,
                        Banner = bannerVm,
                        Image = imageVm,
                        Media = videoVm,
                    };

                    return result;

                }
                else
                    return new HomeViewModel();
            }
            else
            { return new HomeViewModel(); }
     
    
        }

        public async Task<HomeViewModel> UpdateHome(int IdHome, Home model)
        {

             await _homeService.UpdateHome(model.Id, model);
            return new HomeViewModel();
        }
    }
}
