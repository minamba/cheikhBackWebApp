using System;
using System.Collections.Generic;
namespace ApplicationCheikh.Domain.Models;

public partial class Seminaire
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? IdBanner { get; set; }

    public int? IdMedia { get; set; }

    public int? IdImage { get; set; }

    public decimal? Amount { get; set; }

    public bool? Active { get; set; }

    public virtual Image? IdBannerNavigation { get; set; }

    public virtual Media? IdMediaNavigation { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<SeminaireQueue> SeminaireQueues { get; } = new List<SeminaireQueue>();

    public virtual ICollection<Session> Sessions { get; } = new List<Session>();

    public virtual ICollection<Target> Targets { get; } = new List<Target>();

    public virtual ICollection<Theme> Themes { get; } = new List<Theme>();
}
