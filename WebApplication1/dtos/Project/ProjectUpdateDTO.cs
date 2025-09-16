using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.dtos.Project;

public class ProjectUpdateDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? ProjectDescription { get; set; }

    public string? GithubLink { get; set; }

    public int ProfileId { get; set; }

}