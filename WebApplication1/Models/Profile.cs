using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Profile
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

    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public bool IsDeleted { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedDate { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid RowStamp { get; set; }

    
}
