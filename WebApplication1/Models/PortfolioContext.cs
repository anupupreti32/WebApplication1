using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class PortfolioContext : DbContext
{
    public PortfolioContext()
    {
    }

    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certificate> Certificate { get; set; }

    public virtual DbSet<Education> Education { get; set; }

    public virtual DbSet<Profile> Profile { get; set; }

    public virtual DbSet<Project> Project { get; set; }

    public virtual DbSet<Reference> Reference { get; set; }

    public virtual DbSet<Skill> Skill { get; set; }

    public virtual DbSet<WorkExperience> WorkExperience { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

   

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
