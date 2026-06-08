using System;
using System.Collections.Generic;
using System.Text;

namespace StarterApi.Application.DTOs.ProjectDTOs
{
    public class ProjectRequestDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }
    }
}
