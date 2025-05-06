using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ApplicationCheikh.Domain.Models
{
    public class HomeViewModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int? IdBanner { get; set; }

        public int? IdMedia { get; set; }

        public int? IdImage { get; set; }

        public virtual ImageVIewModel? Image { get; set; }

        public virtual ImageVIewModel? Banner { get; set; }

        public virtual MediaViewModel? Media { get; set; }
    }
}
