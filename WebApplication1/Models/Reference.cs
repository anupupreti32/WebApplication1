using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Reference
{
    public int ReferenceId { get; set; }

    public string ReferenceName { get; set; } = null!;

    public string? ReferenceDescription { get; set; }

    public string Email { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string Position { get; set; } = null!;

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
