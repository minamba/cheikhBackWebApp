using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services;
using ApplicationCheikh.Domain.Services.imp;
using AutoMapper;

namespace ApplicationCheikh.Api.Builders.impl
{
    public class WitnessViewModelBuilder : IWitnessViewModelBuilder
    {
        private IWitnessService _witnessService;
        private IMediaViewModelBuilder _mediaService;
        private IMapper _mapper;

        public WitnessViewModelBuilder(IWitnessService witnessService, IMediaViewModelBuilder mediaService, IMapper mapper)
        {
            _witnessService = witnessService;
            _mediaService = mediaService;
            _mapper = mapper;
        }


        public async Task<WitnessViewModel> AddWitness(Witness model)
        {
            var witness =  await _witnessService.AddWitness(model);

            return _mapper.Map<WitnessViewModel>(witness);
        }

        public async Task<bool> DeleteWitness(int IdWitness)
        {
           return await _witnessService.DeleteWitness(IdWitness);
        }

        public async Task<List<WitnessViewModel>> GetWitnessAsync()
        {
            var witnesses = _witnessService.GetWitnessAsync().Result.ToList();

            var result = _mapper.Map<List<WitnessViewModel>>(witnesses);

            foreach(var w in witnesses)
            {
                foreach(var r in result)
                {
                    if (w.Id == r.Id)
                    {
                        var media = _mediaService.GetMediasAsync().Result.FirstOrDefault(x => x.Id == w.IdMedia);

                        r.Media = media;
                    }
                }
            }
            return result;
        }

 


            public async Task<WitnessViewModel> UpdateWitness(int IdWitness, Witness model)
                    {
                        var witness = await _witnessService.UpdateWitness(IdWitness, model);

                        return _mapper.Map<WitnessViewModel>(witness);
                    }
                }
            }
