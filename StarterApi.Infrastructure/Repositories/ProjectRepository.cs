
using Microsoft.EntityFrameworkCore;
using StarterApi.Domain.Entities;
using StarterApi.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Infrastructure.Repositories
{
    internal class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<Project?> GetByIdWithUsersAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Users)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project?> GetByIdWithTasksAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.TaskItems)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> GetByAuthorIdAsync(int authorId)
        {
            return await _context.Projects
                .Where(p => p.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
