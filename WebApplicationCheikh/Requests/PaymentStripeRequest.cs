namespace ApplicationCheikh.Api.Requests
{
    public class PaymentStripeRequest
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string SuccessUrl { get; set; }
        public string CancelUrl { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}
