using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Abstractions;
using Services.Profiles;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<RepositoryDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ILessonService, LessonService>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();
        using RepositoryDbContext dbContext = scope.ServiceProvider.GetRequiredService<RepositoryDbContext>();
        dbContext.Database.MigrateAsync().GetAwaiter().GetResult();
    }
}