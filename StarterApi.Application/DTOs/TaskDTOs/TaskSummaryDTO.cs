using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.TaskDTOs
{
    public class TaskSummaryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }
    }
}
