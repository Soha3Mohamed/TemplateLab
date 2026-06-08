using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.TaskDTOs
{
    public class TaskResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DueDate { get; set; }

        public int UserId { get; set; }

        public string AssignedUserName { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
    }
}
