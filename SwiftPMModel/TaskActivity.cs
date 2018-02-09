using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftPMModel
{
    public class TaskActivity
    {
        public int TaskActivityId { get; set; }
        public int ModuleTaskId { get; set; }
        public string ActivityName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public virtual ModuleTask ModuleTask { get; set; }
        public virtual ICollection<AssignedTask> AssignedTask { get; set; }

    }
}
