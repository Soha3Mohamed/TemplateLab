using StarterApi.Application.DTOs.TaskDTOs;
using StarterApi.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.ProjectDTOs
{
    public class ProjectResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public ICollection<UserSummaryDTO> Users { get; set; }
            = new List<UserSummaryDTO>();

        public ICollection<TaskSummaryDTO> Tasks { get; set; }
            = new List<TaskSummaryDTO>();
    }
}
