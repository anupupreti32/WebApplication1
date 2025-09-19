using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using AutoMapper;
using WebApplication1.Utilities;
using WebApplication1.Repositories.GenericRepositories;
using WebApplication1.Repositories.SpecificRepositories.SkillRepositories;
using WebApplication1.Repositories.SpecificRepositories.EducationRepositories;

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