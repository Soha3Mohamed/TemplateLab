using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.UserDTOs
{
    public class UserUpdateDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }
    }
}
