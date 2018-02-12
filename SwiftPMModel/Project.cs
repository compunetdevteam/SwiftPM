using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwiftPMModel
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string ProjectDescription { get; set; }

        [Range(1, 5, ErrorMessage = "Priority Must be between 1 to 5")]
        public int PriorityLevel { get; set; }
        public virtual ICollection<ProjectModule> ProjectModules { get; set; }
    }
}
