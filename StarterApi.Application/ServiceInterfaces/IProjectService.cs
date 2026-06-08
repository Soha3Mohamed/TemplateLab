using System;
using System.Collections.Generic;
using System.Text;

using StarterApi.Domain.Common;
using StarterApi.Application.DTOs.ProjectDTOs;

namespace StarterApi.Application.ServiceInterfaces
{
    public interface IProjectService
    {
        Task<ServiceResult<IEnumerable<ProjectResponseDTO>>> GetAllProjectsAsync();

        Task<ServiceResult<ProjectResponseDTO>> GetProjectByIdAsync(int id);

        Task<ServiceResult<IEnumerable<ProjectResponseDTO>>>
            GetProjectsByAuthorAsync(int authorId);

        Task<ServiceResult<ProjectResponseDTO>>
            CreateProjectAsync(ProjectRequestDTO request);

        Task<ServiceResult<ProjectResponseDTO>>
            UpdateProjectAsync(int id, UpdateProjectDTO request);

        Task<ServiceResult<bool>>
            DeleteProjectAsync(int id);

        Task<ServiceResult<string>>
            AddUserToProjectAsync(int projectId, int userId);

        Task<ServiceResult<string>>
            RemoveUserFromProjectAsync(int projectId, int userId);
    }
}
