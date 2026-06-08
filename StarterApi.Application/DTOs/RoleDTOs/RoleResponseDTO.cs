using StarterApi.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.RoleDTOs
{
    public class RoleResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserSummaryDTO> Users { get; set; }
            = new List<UserSummaryDTO>();
    }
}
