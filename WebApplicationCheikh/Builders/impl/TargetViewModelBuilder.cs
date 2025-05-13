using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class TargetViewModelBuilder : ITargetViewModelBuilder
    {
        private ITargetService _targetService;
        private ISeminaireViewModelBuilder _seminaireService;
        private IMapper _mapper;




        public TargetViewModelBuilder(ITargetService targetService, ISeminaireViewModelBuilder seminaireService, IMapper mapper)
        {
            _targetService = targetService;
            _seminaireService = seminaireService;
            _mapper = mapper;
        }

        public async Task<TargetViewModel> AddTarget(Target model)
        {
            var target = await _targetService.AddTarget(model);

            var seminaireVm = _seminaireService.GetSeminaires().Result.FirstOrDefault(x => x.Id == model.IdSeminaire);

            var result = _mapper.Map<TargetViewModel>(target);
            result.Seminaire = seminaireVm;

            return result;
        }


        public async Task<bool> DeleteTarget(int IdTarget)
        {
            return await _targetService.DeleteTarget(IdTarget);
        }

        public async Task<List<TargetViewModel>> GetTargetsAsync()
        {
            var targets = _targetService.GetTargetsAsync().Result.ToList();
            var list = new List<TargetViewModel>();

            var result = _mapper.Map<List<TargetViewModel>>(targets);

            foreach (var target in targets)
            {
                foreach (var r in result)
                {
                    var SeminaireVM = _seminaireService.GetSeminaires().Result.FirstOrDefault(s => s.Id == target.IdSeminaire);

                    r.Seminaire = SeminaireVM;
                }

            }

            return result;
        }



        public async Task<TargetViewModel> UpdateTarget(int IdTarget, Target model)
        {
            var target = await _targetService.UpdateTarget(IdTarget, model);

            return _mapper.Map<TargetViewModel>(target);
        }
    }
}
