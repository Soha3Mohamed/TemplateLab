using Microsoft.Extensions.DependencyInjection;
using StarterApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            // Add repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}
