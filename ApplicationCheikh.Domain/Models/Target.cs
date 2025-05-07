using System;
using System.Collections.Generic;

namespace ApplicationCheikh.Domain.Models;

public partial class Target
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Detail { get; set; }

    public int IdSeminaire { get; set; }

    public virtual Seminaire IdSeminaireNavigation { get; set; } = null!;
}
