using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class ThemeViewModelBuilder : IThemeViewModelBuilder
    {
        private IThemeService _themeService;
        private ISeminaireViewModelBuilder _seminaireService;
        private IMapper _mapper;




        public ThemeViewModelBuilder(IThemeService themeService, ISeminaireViewModelBuilder seminaireService, IMapper mapper)
        {
            _themeService = themeService;
            _seminaireService = seminaireService;
            _mapper = mapper;
        }

        public async Task<ThemeViewModel> AddTheme(Theme model)
        {
            var Theme = await _themeService.AddTheme(model);

            var seminaireVm = _seminaireService.GetSeminaires().Result.FirstOrDefault(x => x.Id == model.IdSeminaire);

            var result = _mapper.Map<ThemeViewModel>(Theme);
            result.Seminaire = seminaireVm;

            return result;
        }


        public async Task<bool> DeleteTheme(int IdTheme)
        {
            return await _themeService.DeleteTheme(IdTheme);
        }

        public async Task<List<ThemeViewModel>> GetThemesAsync()
        {
            var Themes = _themeService.GetThemesAsync().Result.ToList();
            var seminaires = _seminaireService.GetSeminaires().Result.ToList();

            var list = new List<ThemeViewModel>();

            var result = _mapper.Map<List<ThemeViewModel>>(Themes);

            foreach (var r in result)
            {
                foreach (var t in Themes)
                {

                        if (t.Id == r.Id)
                        {
                            var SeminaireVM = _seminaireService.GetSeminaires().Result.FirstOrDefault(s => s.Id == t.IdSeminaire);

                            r.Seminaire = SeminaireVM;
                        }
                }

            }

            return result;
        }



        public async Task<ThemeViewModel> UpdateTheme(int IdTheme, Theme model)
        {
            var Theme = await _themeService.UpdateTheme(IdTheme, model);

            return _mapper.Map<ThemeViewModel>(Theme);
        }
    }
}
