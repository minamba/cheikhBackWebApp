using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface IMediaViewModelBuilder
    {
        Task<List<MediaViewModel>> GetMediasAsync();
        Task<MediaViewModel> AddMedia(Media model);
        Task<MediaViewModel> UpdateMedia(int IdMedia, Media model);
        Task<bool> DeleteMedia(int IdMedia);
    }
}
