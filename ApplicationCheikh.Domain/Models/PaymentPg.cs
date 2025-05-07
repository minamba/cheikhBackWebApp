using System;
using System.Collections.Generic;

namespace ApplicationCheikh.Domain.Models;

public partial class PaymentPg
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? IdBanner { get; set; }
}
