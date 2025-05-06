using System;
using System.Collections.Generic;

namespace MIAdbConsole.Models;

public partial class Session
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Detail { get; set; }

    public int IdSeminaire { get; set; }

    public virtual Seminaire IdSeminaireNavigation { get; set; } = null!;
}
