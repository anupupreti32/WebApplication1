using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTOS.Project;

public class ProjectReadDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectId { get; set; }

    public required string ProjectName { get; set; } 

    public string? ProjectDescription { get; set; }

    public string? GithubLink { get; set; }

    public int ProfileId { get; set; }

}