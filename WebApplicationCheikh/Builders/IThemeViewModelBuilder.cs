using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.Builders
{
    public interface IThemeViewModelBuilder
    {
        Task<List<ThemeViewModel>> GetThemesAsync();
        Task<ThemeViewModel> AddTheme(Theme model);
        Task<ThemeViewModel> UpdateTheme(int Idtheme, Theme model);
        Task<bool> DeleteTheme(int IdTheme);
    }
}
