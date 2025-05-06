using System;
using System.Collections.Generic;

namespace MIAdbConsole.Models;

public partial class PaymentPg
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? IdBanner { get; set; }
}
