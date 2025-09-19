using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTOS.Skill;

public class SkillUpdateDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SkillId { get; set; }

    public required string SkillName { get; set; }

    public string? SkillDescription { get; set; }

    public int ProfileId { get; set; }
}