using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class WorkExperience
{
    public int WorkExperienceId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string Address { get; set; } = null!;

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
