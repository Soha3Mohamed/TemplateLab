using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.RoleDTOs
{
    public class UpdateRoleDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
