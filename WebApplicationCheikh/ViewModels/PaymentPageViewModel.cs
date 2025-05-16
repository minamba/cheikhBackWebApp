using ApplicationCheikh.Domain.Models;

namespace ApplicationCheikh.Api.ViewModels
{
    public class PaymentPageViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public ImageVIewModel? Banner { get; set; }
    }
}
