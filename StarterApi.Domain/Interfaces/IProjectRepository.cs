using StarterApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Infrastructure.Repositories
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(int id);

        Task<Project?> GetByIdWithUsersAsync(int id);

        Task<Project?> GetByIdWithTasksAsync(int id);

        Task<IEnumerable<Project>> GetAllAsync();

        Task<IEnumerable<Project>> GetByAuthorIdAsync(int authorId);

        Task AddAsync(Project project);

        Task UpdateAsync(Project project);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
