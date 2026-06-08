using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.TaskDTOs
{
    public class UpdateTaskDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
