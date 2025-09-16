using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public partial class Skill
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SkillId { get; set; }

    public string SkillName { get; set; } = null!;

    public string? SkillDescription { get; set; }

    public int ProfileId { get; set; }

    //public virtual Profile Profile { get; set; } = null!;
}
