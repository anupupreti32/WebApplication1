using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Education
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EducationId { get; set; }

    public required string InstututionName { get; set; } 

    public string Degree { get; set; } = null!;

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public int ProfileId { get; set; }

    //public virtual Profile Profile { get; set; } = null!;
}
