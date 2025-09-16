using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public partial class Profile
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProfileId { get; set; }

    public string ProfileName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ProfileContactNumber { get; set; } = null!;

    public string? Title { get; set; }

    public DateTime Dob { get; set; }

    public string? GithubLink { get; set; }

    public string Email { get; set; } = null!;

    public string LinkedInLink { get; set; } = null!;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public bool IsDeleted { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid RowStamp { get; set; }

    
}
