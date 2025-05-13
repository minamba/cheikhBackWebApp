using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface IImageViewModelBuilder
    {
        Task<List<ImageVIewModel>> GetImagesAsync();
        Task<ImageVIewModel> AddImage(Image model);
        Task<ImageVIewModel> UpdateImage(int IdImage, Image model);
        Task<bool> DeleteImage(int IdImage);
    }
}
