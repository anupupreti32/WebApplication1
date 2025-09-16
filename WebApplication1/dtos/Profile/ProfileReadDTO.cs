namespace WebApplication1.dtos.Profile;

public class ProfileReadDto
{
    public int ProfileId { get; set; }

    public string ProfileName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ProfileContactNumber { get; set; } = null!;

    public string? Title { get; set; }

    public DateTime Dob { get; set; }

    public string? GithubLink { get; set; }

    public string Email { get; set; } = null!;

    public string LinkedInLink { get; set; } = null!;

}