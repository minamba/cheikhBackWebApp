using System;
using System.Collections.Generic;

namespace ApplicationCheikh.Domain.Models;
public partial class Home
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? IdBanner { get; set; }

    public int? IdMedia { get; set; }

    public int? IdImage { get; set; }

    public virtual Image? IdImageNavigation { get; set; }

    public virtual Media? IdMediaNavigation { get; set; }
}
