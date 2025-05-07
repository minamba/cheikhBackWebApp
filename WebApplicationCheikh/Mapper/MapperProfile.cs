using ApplicationCheikh.Domain.Models;
using Profile = AutoMapper.Profile;

namespace ApplicationCheikh.Api.Mapper
{
    public class MapperProfile : Profile
    {

        public MapperProfile() {

            CreateMap<RegistrationQueue, RegistrationQueueViewModel>()
                .ForMember(x => x.Id, dest => dest.MapFrom(x => x.Id))
                .ForMember(x => x.LastName, dest => dest.MapFrom(x => x.LastName))
                .ForMember(x => x.FirstName, dest => dest.MapFrom(x => x.FirstName))
                .ForMember(x => x.PhoneNumber, dest => dest.MapFrom(x => x.PhoneNumber))
                .ForMember(x => x.Email, dest => dest.MapFrom(x => x.Email))
                .ForMember(x => x.Date, dest => dest.MapFrom(x => x.Date))
                .ForMember(x => x.IsContacted, dest => dest.MapFrom(x => x.IsContacted))
                .ForMember(x => x.SendedToBot, dest => dest.MapFrom(x => x.SendedToBot));

            CreateMap<SeminaireQueue, SeminaireQueueViewModel>()
                .ForMember(x => x.Id, dest => dest.MapFrom(x => x.Id))
                .ForMember(x => x.LastName, dest => dest.MapFrom(x => x.LastName))
                .ForMember(x => x.FirstName, dest => dest.MapFrom(x => x.FirstName))
                .ForMember(x => x.Email, dest => dest.MapFrom(x => x.Email))
                .ForMember(x => x.Date, dest => dest.MapFrom(x => x.Date))
                .ForMember(x => x.MailSent, dest => dest.MapFrom(x => x.MailSent));


            CreateMap<Payment, PaymentViewModel>()
             .ForMember(x => x.Id, dest => dest.MapFrom(x => x.Id))
             .ForMember(x => x.LastName, dest => dest.MapFrom(x => x.LastName))
             .ForMember(x => x.FirstName, dest => dest.MapFrom(x => x.FirstName))
             .ForMember(x => x.Mail, dest => dest.MapFrom(x => x.Mail))
             .ForMember(x => x.Amount, dest => dest.MapFrom(x => x.Amount))
             .ForMember(x => x.PaymentMode, dest => dest.MapFrom(x => x.PaymentMode))
             .ForMember(x => x.Date, dest => dest.MapFrom(x => x.Date));
        }
    }
}
