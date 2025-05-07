using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Models
{
    public class RegistrationQueueViewModel
    {
        public int Id { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public DateTime? Date { get; set; }

        public bool? IsContacted { get; set; }

        public bool? SendedToBot { get; set; }
    }
}
