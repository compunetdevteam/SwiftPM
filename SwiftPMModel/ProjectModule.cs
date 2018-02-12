using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SwiftPMModel
{
    public class ProjectModule
    {
        public int ProjectModuleId { get; set; }
        public int ProjectId { get; set; }
        public string ModuleName { get; set; }

        [Range(1, 5, ErrorMessage = "Priority Must be between 1 to 5")]
        public int PriorityLevel { get; set; }

        public double? ModulePercentage { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public virtual Project Project { get; set; }
        public virtual ICollection<ModuleTask> ModuleTasks { get; set; }
    }
}
