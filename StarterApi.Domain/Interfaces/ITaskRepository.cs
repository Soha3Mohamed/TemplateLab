using StarterApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(int id);

        Task<IEnumerable<TaskItem>> GetAllAsync();

        Task<IEnumerable<TaskItem>> GetByUserIdAsync(int userId);

        Task<IEnumerable<TaskItem>> GetByProjectIdAsync(int projectId);

        Task AddAsync(TaskItem task);

        Task UpdateAsync(TaskItem task);

        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
