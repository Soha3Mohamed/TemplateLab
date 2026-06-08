using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.UserDTOs
{
    public class UserRequestDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; } 
    }
}
