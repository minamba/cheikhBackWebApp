using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Dal.Dto
{
    public class ThemeDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Detail { get; set; }

        public int IdSeminaire { get; set; }
    }
}
