using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.ViewModels
{
    public class CloseRegistrationViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public ImageVIewModel Banner { get; set; }
    }
}
