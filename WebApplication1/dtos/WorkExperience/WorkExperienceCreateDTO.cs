using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.dtos.WorkExperience;

public class WorkExperienceCreateDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WorkExperienceId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string Address { get; set; } = null!;

    public int ProfileId { get; set; }
}