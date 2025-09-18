using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class WorkExperience
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WorkExperienceId { get; set; }

    public required string CompanyName { get; set; } 

    public required string Role { get; set; } 

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public required string Address { get; set; } 

    public int ProfileId { get; set; }

    //public virtual Profile Profile { get; set; } = null!;
}
