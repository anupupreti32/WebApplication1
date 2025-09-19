using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Skill
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SkillId { get; set; }

    public required string SkillName { get; set; } 

    public string? SkillDescription { get; set; }

    public int ProfileId { get; set; }

    //public virtual Profile Profile { get; set; } = null!;
}
