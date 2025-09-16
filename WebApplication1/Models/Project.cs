using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? ProjectDescription { get; set; }

    public string? GithubLink { get; set; }

    public int ProfileId { get; set; }

    public virtual Profile Profile { get; set; } = null!;
}
