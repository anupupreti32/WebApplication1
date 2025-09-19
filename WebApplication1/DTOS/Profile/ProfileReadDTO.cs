using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.DTOS.Profile;

public class ProfileReadDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProfileId { get; set; }

    public required string ProfileName { get; set; }

    public required string Address { get; set; } 

    public required string ProfileContactNumber { get; set; } 

    public string? Title { get; set; }

    public DateTime Dob { get; set; }

    public string? GithubLink { get; set; }

    public required string Email { get; set; }

    public required string LinkedInLink { get; set; }

}