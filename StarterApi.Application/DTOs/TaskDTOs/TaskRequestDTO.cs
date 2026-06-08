using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.TaskDTOs
{
    public class TaskRequestDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
