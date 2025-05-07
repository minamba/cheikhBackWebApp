using System;
using System.Collections.Generic;

namespace ApplicationCheikh.Domain.Models;

public partial class Registration
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? IdBanner { get; set; }
}
