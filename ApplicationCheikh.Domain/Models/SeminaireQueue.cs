using System;
using System.Collections.Generic;

namespace ApplicationCheikh.Domain.Models;

public partial class SeminaireQueue
{
    public int Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Email { get; set; }

    public DateTime? Date { get; set; }

    public bool? MailSent { get; set; }

    public int? IdSeminaire { get; set; }

    public virtual Seminaire? IdSeminaireNavigation { get; set; }
}
