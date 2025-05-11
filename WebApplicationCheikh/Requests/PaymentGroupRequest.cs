namespace ApplicationCheikh.Api.Requests
{
    public class PaymentGroupRequest
    {
        public IEnumerable<string> RecipientList { get; set; }
        public string SeminaireTitle { get; set; }
    }
}
