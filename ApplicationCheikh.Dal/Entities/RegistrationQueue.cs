using System;
using System.Collections.Generic;

namespace MIAdbConsole.Models;

public partial class RegistrationQueue
{
    public int Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateTime? Date { get; set; }

    public bool? IsContacted { get; set; }

    public bool? SendedToBot { get; set; }
}
