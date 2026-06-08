using System;
using System.Collections.Generic;
using System.Text;

using StarterApi.Domain.Common;
using StarterApi.Application.DTOs.TaskDTOs;

namespace StarterApi.Application.ServiceInterfaces
{
    public interface ITaskService
    {
        Task<ServiceResult<IEnumerable<TaskResponseDTO>>> GetAllTasksAsync();

        Task<ServiceResult<TaskResponseDTO>> GetTaskByIdAsync(int id);

        Task<ServiceResult<IEnumerable<TaskResponseDTO>>>
            GetTasksByUserAsync(int userId);

        Task<ServiceResult<IEnumerable<TaskResponseDTO>>>
            GetTasksByProjectAsync(int projectId);

        Task<ServiceResult<TaskResponseDTO>>
            CreateTaskAsync(TaskRequestDTO request);

        Task<ServiceResult<TaskResponseDTO>>
            UpdateTaskAsync(int id, UpdateTaskDTO request);

        Task<ServiceResult<bool>>
            DeleteTaskAsync(int id);

        Task<ServiceResult<string>>
            AssignTaskToUserAsync(int taskId, int userId);

        Task<ServiceResult<string>>
            ChangeTaskStatusAsync(int taskId, string status);
    }
}
