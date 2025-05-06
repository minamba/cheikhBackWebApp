using System;
using System.Collections.Generic;

namespace MIAdbConsole.Models;

public partial class Media
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Url { get; set; }

    public int? Type { get; set; }

    public virtual ICollection<Home> Homes { get; } = new List<Home>();

    public virtual ICollection<Seminaire> Seminaires { get; } = new List<Seminaire>();

    public virtual ICollection<Witness> Witnesses { get; } = new List<Witness>();
}
