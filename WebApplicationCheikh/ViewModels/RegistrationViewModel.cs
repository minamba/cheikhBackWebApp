using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.ViewModels
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public bool? IsClosed { get; set; }

        public ImageVIewModel Image { get; set; }
    }

}

