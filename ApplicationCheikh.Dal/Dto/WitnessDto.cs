using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Dal.Dto
{
    public class WitnessDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public int? IdMedia { get; set; }
    }
}
