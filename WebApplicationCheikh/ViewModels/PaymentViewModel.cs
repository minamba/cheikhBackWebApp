using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCheikh.Domain.Models
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Mail { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? Date { get; set; }

        public string? PaymentMode { get; set; }

        public SeminaireViewModel? Seminaire { get; set; }
    }
}
