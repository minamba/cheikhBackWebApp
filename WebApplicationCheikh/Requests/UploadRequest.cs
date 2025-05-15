namespace ApplicationCheikh.Api.Requests
{
    public class UploadRequest
    {
        public IFormFile File { get; set; }
        public string Type { get; set; }
    }
}
