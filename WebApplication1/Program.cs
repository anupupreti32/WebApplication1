using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using AutoMapper;
using WebApplication1.Repositories.GenericRepositories;
using WebApplication1.Repositories.SpecificRepositories.ReferenceRepositories;
using WebApplication1.Utilities;
using WebApplication1.Repositories.GenericRepositories;
using WebApplication1.Repositories.SpecificRepositories.SkillRepositories;
using WebApplication1.Repositories.SpecificRepositories.EducationRepositories;
using WebApplication1.Repositories.SpecificRepositories.CertificateRepositories;
using WebApplication1.Repositories.SpecificRepositories.WorkExperienceRepositories;
using WebApplication1.Repositories.SpecificRepositories.ProjectRepositories;
using WebApplication1.Repositories.SpecificRepositories.ProfileRepositories;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Register the DbContext for dependency injection.
builder.Services.AddDbContext<PortfolioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGenericRepositories,GenericRepositories>();
builder.Services.AddScoped<IEducationRepositories,EducationRepositories>();
builder.Services.AddScoped<ISkillRepositories, SkillRepositories>();
builder.Services.AddScoped<IReferenceRepositories, ReferenceRepositories>();
builder.Services.AddScoped<ICertificateRepositories, CertificateRepositories>();
builder.Services.AddScoped<IWorkExperienceRepositories, WorkExperienceRepositories>();
builder.Services.AddScoped<IProjectRepositories, ProjectRepositories>();
builder.Services.AddScoped<IProfileRepositories, ProfileRepositories>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();