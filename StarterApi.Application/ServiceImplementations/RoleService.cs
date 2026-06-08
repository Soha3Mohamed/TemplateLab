using AutoMapper;
using Microsoft.Extensions.Logging;
using StarterApi.Application.DTOs.RoleDTOs;
using StarterApi.Application.ServiceInterfaces;
using StarterApi.Domain.Common;
using StarterApi.Domain.Entities;
using StarterApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.ServiceImplementations
{
    internal class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleService> _logger;

        public RoleService(IRoleRepository roleRepository, IMapper mapper, ILogger<RoleService> logger)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResult<IEnumerable<RoleResponseDTO>>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllAsync();

            if (!roles.Any())
                return ServiceResult<IEnumerable<RoleResponseDTO>>.Fail("No roles found");

            return ServiceResult<IEnumerable<RoleResponseDTO>>.Ok(
                _mapper.Map<IEnumerable<RoleResponseDTO>>(roles));
        }

        public async Task<ServiceResult<RoleResponseDTO>> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role == null)
                return ServiceResult<RoleResponseDTO>.Fail("Role not found");

            return ServiceResult<RoleResponseDTO>.Ok(_mapper.Map<RoleResponseDTO>(role));
        }

        public async Task<ServiceResult<RoleResponseDTO>> CreateRoleAsync(RoleRequestDTO request)
        {
            var role = _mapper.Map<Role>(request);

            await _roleRepository.AddAsync(role);
            await _roleRepository.SaveChangesAsync();

            return ServiceResult<RoleResponseDTO>.Ok(_mapper.Map<RoleResponseDTO>(role));
        }

        public async Task<ServiceResult<RoleResponseDTO>> UpdateRoleAsync(int id, UpdateRoleDTO request)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role == null)
                return ServiceResult<RoleResponseDTO>.Fail("Role not found");

            _mapper.Map(request, role);

            await _roleRepository.UpdateAsync(role);
            await _roleRepository.SaveChangesAsync();

            return ServiceResult<RoleResponseDTO>.Ok(_mapper.Map<RoleResponseDTO>(role));
        }

        public async Task<ServiceResult<bool>> DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteAsync(id);
            await _roleRepository.SaveChangesAsync();

            return ServiceResult<bool>.Ok(true);
        }

    }
}
