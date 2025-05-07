using System;
using System.Collections.Generic;

namespace ApplicationCheikh.Domain.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Mail { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? Date { get; set; }

    public string? PaymentMode { get; set; }
}
