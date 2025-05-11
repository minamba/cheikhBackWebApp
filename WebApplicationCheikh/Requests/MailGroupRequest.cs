namespace ApplicationCheikh.Api.Requests
{
    public class MailGroupRequest
    {
        public IEnumerable<string> RecipientList { get; set; }
        public string SeminaireTitle { get; set; }
    }
}
