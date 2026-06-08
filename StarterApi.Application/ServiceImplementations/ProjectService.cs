using AutoMapper;
using Microsoft.Extensions.Logging;
using StarterApi.Application.DTOs.ProjectDTOs;
using StarterApi.Application.ServiceInterfaces;
using StarterApi.Domain.Common;
using StarterApi.Domain.Entities;
using StarterApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.ServiceImplementations
{
    internal class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(
            IProjectRepository projectRepository,
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<ProjectService> logger)
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<ProjectResponseDTO>>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllAsync();

            return ServiceResult<IEnumerable<ProjectResponseDTO>>.Ok(
                _mapper.Map<IEnumerable<ProjectResponseDTO>>(projects));
        }

        public async Task<ServiceResult<ProjectResponseDTO>> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                return ServiceResult<ProjectResponseDTO>.Fail("Project not found");

            return ServiceResult<ProjectResponseDTO>.Ok(
                _mapper.Map<ProjectResponseDTO>(project));
        }

        public async Task<ServiceResult<IEnumerable<ProjectResponseDTO>>> GetProjectsByAuthorAsync(int authorId)
        {
            var project = await _projectRepository.GetByAuthorIdAsync(authorId);

            if (project == null)
                return ServiceResult< IEnumerable<ProjectResponseDTO>>.Fail("Project not found");

            return ServiceResult<IEnumerable<ProjectResponseDTO>>.Ok(
                _mapper.Map<IEnumerable<ProjectResponseDTO>>(project));
        }

        public async Task<ServiceResult<ProjectResponseDTO>> CreateProjectAsync(ProjectRequestDTO request)
        {
            var user = await _userRepository.GetByIdAsync(request.AuthorId);

            if (user == null)
                return ServiceResult<ProjectResponseDTO>.Fail("Author not found");

            var project = _mapper.Map<Project>(request);

            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();

            return ServiceResult<ProjectResponseDTO>.Ok(
                _mapper.Map<ProjectResponseDTO>(project));
        }

        public async Task<ServiceResult<ProjectResponseDTO>> UpdateProjectAsync(int id, UpdateProjectDTO request)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                return ServiceResult<ProjectResponseDTO>.Fail("Project not found");

            _mapper.Map(request, project);

            await _projectRepository.UpdateAsync(project);
            await _projectRepository.SaveChangesAsync();

            return ServiceResult<ProjectResponseDTO>.Ok(
                _mapper.Map<ProjectResponseDTO>(project));
        }

        public async Task<ServiceResult<bool>> DeleteProjectAsync(int id)
        {
            await _projectRepository.DeleteAsync(id);
            await _projectRepository.SaveChangesAsync();

            return ServiceResult<bool>.Ok(true);
        }

        public async Task<ServiceResult<string>> AddUserToProjectAsync(int projectId, int userId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);
            var user = await _userRepository.GetByIdAsync(userId);

            if (project == null || user == null)
                return ServiceResult<string>.Fail("Project or User not found");

            project.Users.Add(user);

            await _projectRepository.SaveChangesAsync();

            return ServiceResult<string>.Ok("User added to project");
        }

        public async Task<ServiceResult<string>> RemoveUserFromProjectAsync(int projectId, int userId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);

            if (project == null)
                return ServiceResult<string>.Fail("Project not found");

            var user = project.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
                return ServiceResult<string>.Fail("User not in project");

            project.Users.Remove(user);

            await _projectRepository.SaveChangesAsync();

            return ServiceResult<string>.Ok("User removed from project");
        }

     

    }
}
