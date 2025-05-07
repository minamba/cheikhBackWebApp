using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Dal.Dto
{
    public class SeminaireQueueDto
    {
        public int Id { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? Email { get; set; }

        public DateTime? Date { get; set; }

        public bool? MailSent { get; set; }
    }
}
