using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.dtos.Skill;

public class SkillCreateDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SkillId { get; set; }

    public string SkillName { get; set; } = null!;

    public string? SkillDescription { get; set; }

    public int ProfileId { get; set; }
}