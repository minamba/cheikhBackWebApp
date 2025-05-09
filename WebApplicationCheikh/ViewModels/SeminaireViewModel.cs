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

        public ImageVIewModel? Banner { get; set; }

        public MediaViewModel? Video { get; set; }

        public ImageVIewModel? Graphic { get; set; }

        public decimal? Amount { get; set; }

        public bool? Active { get; set; }

    }
}
