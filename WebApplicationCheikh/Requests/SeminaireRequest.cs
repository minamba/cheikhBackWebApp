namespace ApplicationCheikh.Api.Requests
{
    public class SeminaireRequest
    {

        public string? Title { get; set; }

        public int? IdBanner { get; set; }

        public int? IdMedia { get; set; }

        public int? IdImage { get; set; }

        public decimal? Amount { get; set; }

        public bool? Active { get; set; }
    }
}
