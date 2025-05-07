using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Dal.Dto
{
    public class MediaDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Url { get; set; }

        public int? Type { get; set; }
    }
}
