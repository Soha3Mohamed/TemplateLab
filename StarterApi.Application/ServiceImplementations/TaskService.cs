using AutoMapper;
using StarterApi.Application.DTOs.TaskDTOs;
using StarterApi.Application.ServiceInterfaces;
using StarterApi.Domain.Common;
using StarterApi.Domain.Entities;
using StarterApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.ServiceImplementations
{
    internal class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public TaskService(
            ITaskRepository taskRepository,
            IUserRepository userRepository,
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<TaskResponseDTO>>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();

            return ServiceResult<IEnumerable<TaskResponseDTO>>.Ok(
                _mapper.Map<IEnumerable<TaskResponseDTO>>(tasks));
        }

        public async Task<ServiceResult<TaskResponseDTO>> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
                return ServiceResult<TaskResponseDTO>.Fail("Task not found");

            return ServiceResult<TaskResponseDTO>.Ok(
                _mapper.Map<TaskResponseDTO>(task));
        }
        public async Task<ServiceResult<IEnumerable<TaskResponseDTO>>> GetTasksByUserAsync(int userId)
        {
            var tasks = await _taskRepository.GetByUserIdAsync(userId);

            if (tasks == null || !tasks.Any())
                return ServiceResult<IEnumerable<TaskResponseDTO>>.Fail("No tasks found for this user");

            return ServiceResult<IEnumerable<TaskResponseDTO>>.Ok(
                _mapper.Map<IEnumerable<TaskResponseDTO>>(tasks));
        }
        public async Task<ServiceResult<IEnumerable<TaskResponseDTO>>> GetTasksByProjectAsync(int projectId)
        {
            var tasks = await _taskRepository.GetByProjectIdAsync(projectId);

            if (tasks == null || !tasks.Any())
                return ServiceResult<IEnumerable<TaskResponseDTO>>.Fail("No tasks found for this project");

            return ServiceResult<IEnumerable<TaskResponseDTO>>.Ok(
                _mapper.Map<IEnumerable<TaskResponseDTO>>(tasks));
        }

        public async Task<ServiceResult<TaskResponseDTO>> CreateTaskAsync(TaskRequestDTO request)
        {
            var task = _mapper.Map<TaskItem>(request);

            await _taskRepository.AddAsync(task);
            await _taskRepository.SaveChangesAsync();

            return ServiceResult<TaskResponseDTO>.Ok(
                _mapper.Map<TaskResponseDTO>(task));
        }

        public async Task<ServiceResult<TaskResponseDTO>> UpdateTaskAsync(int id, UpdateTaskDTO request)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null)
                return ServiceResult<TaskResponseDTO>.Fail("Task not found");

            _mapper.Map(request, task);

            await _taskRepository.UpdateAsync(task);
            await _taskRepository.SaveChangesAsync();

            return ServiceResult<TaskResponseDTO>.Ok(
                _mapper.Map<TaskResponseDTO>(task));
        }

        public async Task<ServiceResult<bool>> DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
            await _taskRepository.SaveChangesAsync();

            return ServiceResult<bool>.Ok(true);
        }

        public async Task<ServiceResult<string>> AssignTaskToUserAsync(int taskId, int userId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            var user = await _userRepository.GetByIdAsync(userId);

            if (task == null || user == null)
                return ServiceResult<string>.Fail("Task or User not found");

            task.UserId = userId;

            await _taskRepository.SaveChangesAsync();

            return ServiceResult<string>.Ok("Task assigned successfully");
        }

        public async Task<ServiceResult<string>> ChangeTaskStatusAsync(int taskId, string status)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);

            if (task == null)
                return ServiceResult<string>.Fail("Task not found");

            if (!Enum.TryParse<TaskStatus>(status, true, out var parsedStatus))
                return ServiceResult<string>.Fail("Invalid status");

            task.Status = (Domain.Enums.TaskItemStatus)parsedStatus;

            await _taskRepository.SaveChangesAsync();

            return ServiceResult<string>.Ok("Status updated");
        }

      

    }
}
