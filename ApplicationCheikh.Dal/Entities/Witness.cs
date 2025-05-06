using System;
using System.Collections.Generic;

namespace MIAdbConsole.Models;

public partial class Witness
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? IdMedia { get; set; }

    public virtual Media? IdMediaNavigation { get; set; }
}
