using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Education
{
    public int EducationId { get; set; }

    public string InstututionName { get; set; } = null!;

    public string Degree { get; set; } = null!;

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
