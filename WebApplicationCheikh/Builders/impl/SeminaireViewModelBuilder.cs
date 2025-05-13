using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class SeminaireViewModelBuilder : ISeminaireViewModelBuilder
    {

        private ISeminaireService _seminaireService;
        private IImageService _imageService;
        private IMediaService _mediaService;
        private IMapper _mapper;

        public SeminaireViewModelBuilder(ISeminaireService seminaireService, IImageService imageService, IMediaService mediaService, IMapper mapper)
        {
            _seminaireService = seminaireService;
            _imageService = imageService;
            _mediaService = mediaService;
            _mapper = mapper;
        }
        public async Task<SeminaireViewModel> AddSeminaire(Seminaire model)
        {
            var sem = await _seminaireService.AddSeminaire(model);

            var result = new SeminaireViewModel
            {
                Title = model.Title,
                Amount = model.Amount,
                Banner = new ImageVIewModel(),
                Graphic = new ImageVIewModel(),
                Video = new MediaViewModel(),
                Active = model.Active,
                
            };

            return result;
        }

        public async Task<bool> DeleteSeminaire(int IdSeminaire)
        {
            return await _seminaireService.DeleteSeminaire(IdSeminaire);
        }

        public async Task<List<SeminaireViewModel>> GetSeminaires()
        {
            var sems = await _seminaireService.GetSeminaires();

            var result = new List<SeminaireViewModel>();

            foreach (var se in sems)
            {
                var banner = _imageService.GetImagesAsync().Result.FirstOrDefault(x => x.Id == se.IdBanner);
                var image = _imageService.GetImagesAsync().Result.FirstOrDefault(x => x.Id == se.IdImage);
                var video = _mediaService.GetMediasAsync().Result.FirstOrDefault(x => x.Id == se.IdMedia);

                var bannerVm = _mapper.Map<ImageVIewModel>(banner);
                var imageVm = _mapper.Map<ImageVIewModel>(image);
                var videoVm = _mapper.Map<MediaViewModel>(video);


                var seminaire = new SeminaireViewModel
                {
                    Id = se.Id,
                    Title = se.Title,
                    Amount = se.Amount,
                    Banner = bannerVm,
                    Graphic = imageVm,
                    Video = videoVm,
                    Active = se.Active,
                };

                result.Add(seminaire);
            }

            return result;
        }

        public async Task<SeminaireViewModel> UpdateSeminaire(int IdSeminaire, Seminaire model)
        {
            var sem = await _seminaireService.UpdateSeminaire(IdSeminaire, model);

            var banner = _imageService.GetImagesAsync().Result.FirstOrDefault(x => x.Id == sem.IdBanner);
            var image = _imageService.GetImagesAsync().Result.FirstOrDefault(x => x.Id == sem.IdImage);
            var video = _mediaService.GetMediasAsync().Result.FirstOrDefault(x => x.Id == sem.IdMedia);

            var bannerVm = _mapper.Map<ImageVIewModel>(banner);
            var imageVm = _mapper.Map<ImageVIewModel>(image);
            var videoVm = _mapper.Map<MediaViewModel>(video);

            var result = new SeminaireViewModel
            {
                Title = model.Title,
                Amount = model.Amount,
                Banner = bannerVm,
                Graphic = imageVm,
                Video = videoVm,
                Active = model.Active,
            };

            return result;
        }
    }
}
