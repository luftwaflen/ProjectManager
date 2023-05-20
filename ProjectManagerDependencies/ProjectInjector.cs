using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagerApplication.Services.Implementations;
using ProjectManagerApplication.Services.Interfaces;
using ProjectManagerCore.Contracts.Repositories;
using ProjectManagerCore.Models;
using ProjectManagerInfrastructure;
using ProjectManagerInfrastructure.Repositories;

namespace ProjectManagerDependencies;

public static class ProjectInjector
{
    public static void AddRepositories(this IServiceCollection services, string connection)
    {
        services.AddDbContext<PMDbContext>(options =>
        {
            options
                .UseSqlite(connection)
                .LogTo(Console.WriteLine);
        });

        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IWorkTimeRepository, WorkTimeRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IWorkTimeService, WorkTImeService>();
    }
}