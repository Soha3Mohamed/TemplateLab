using System;
using System.Collections.Generic;
using System.Text;

using StarterApi.Domain.Common;
using StarterApi.Application.DTOs.RoleDTOs;

namespace StarterApi.Application.ServiceInterfaces
{

   
        public interface IRoleService
        {
            Task<ServiceResult<IEnumerable<RoleResponseDTO>>> GetAllRolesAsync();

            Task<ServiceResult<RoleResponseDTO>> GetRoleByIdAsync(int id);

            Task<ServiceResult<RoleResponseDTO>> CreateRoleAsync(RoleRequestDTO request);

            Task<ServiceResult<RoleResponseDTO>> UpdateRoleAsync(
                int id,
                UpdateRoleDTO request);

            Task<ServiceResult<bool>> DeleteRoleAsync(int id);
          }
}
