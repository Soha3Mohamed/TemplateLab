using StarterApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Infrastructure.Repositories
{
    public interface IRoleRepository
    {
        Task<Role?> GetByIdAsync(int id);
        Task<Role?> GetByNameAsync(string name);
        Task<IEnumerable<Role>> GetAllAsync();

        Task AddAsync(Role role);
        Task UpdateAsync(Role role);
        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
