using System;
using System.Collections.Generic;

namespace ApplicationCheikh.Domain.Models;

public partial class Image
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Url { get; set; }

    public virtual ICollection<Home> Homes { get; } = new List<Home>();

    public virtual ICollection<Seminaire> Seminaires { get; } = new List<Seminaire>();
}
