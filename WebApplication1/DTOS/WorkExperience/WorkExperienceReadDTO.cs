using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTOS.WorkExperience;

public class WorkExperienceReadDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WorkExperienceId { get; set; }

    public required string CompanyName { get; set; } 

    public required string Role { get; set; } 

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public required string Address { get; set; } 

    public int ProfileId { get; set; }
}