using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTOS.Education;

public class EducationReadDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EducationId { get; set; }

    public required string InstututionName { get; set; } 

    public required string Degree { get; set; } 

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public int ProfileId { get; set; }
}