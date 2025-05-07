using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Models
{
    public class SeminaireViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int? IdBanner { get; set; }

        public int? IdMedia { get; set; }

        public int? IdImage { get; set; }

        public decimal? Amount { get; set; }

        public bool? Active { get; set; }

    }
}
