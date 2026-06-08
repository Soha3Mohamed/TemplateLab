using StarterApi.Application.DTOs.ProjectDTOs;
using StarterApi.Application.DTOs.TaskDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.UserDTOs
{
    public class UserResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public string RoleName { get; set; }

        public ICollection<ProjectSummaryDTO> Projects { get; set; }
            = new List<ProjectSummaryDTO>();

        public ICollection<TaskSummaryDTO> AssignedTasks { get; set; }
            = new List<TaskSummaryDTO>();
    }
}
