namespace WebApplication1.dtos.Education;

public class EducationCreateDTO
{
    public int EducationId { get; set; }

    public string InstututionName { get; set; } = null!;

    public string Degree { get; set; } = null!;

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public int ProfileId { get; set; }
}