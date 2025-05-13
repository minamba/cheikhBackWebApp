using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class ImageViewModelBuilder : IImageViewModelBuilder
    {
        private IImageService _imageService;
        private IMapper _mapper;


        public ImageViewModelBuilder(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<ImageVIewModel> AddImage(Image model)
        {
            var result = await _imageService.AddImage(model);

            return new ImageVIewModel
            {
                Id = result.Id,
                Title = result.Title,
                Url = result.Url,
            };
        }

        public async Task<bool> DeleteImage(int IdImage)
        {
            return await _imageService.DeleteImage(IdImage);
        }

        public async Task<List<ImageVIewModel>> GetImagesAsync()
        {
            var list = new List<ImageVIewModel>();
            var imageList = await _imageService.GetImagesAsync();

            foreach (var item in imageList)
            {
                var img = new ImageVIewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Url = item.Url,
                };

                list.Add(img);
            }

            return list;
        }

        public async Task<ImageVIewModel> UpdateImage(int IdImage, Image model)
        {
            var ImageToUpdate = await _imageService.UpdateImage(IdImage, model);

            var result = _mapper.Map<ImageVIewModel>(ImageToUpdate);

            return result;
        }
    }
}
