using System;
using System.Collections.Generic;

namespace SwiftPMModel
{
    public class ModuleTask
    {
        public int ModuleTaskId { get; set; }
        
        public string ModuleTaskName { get; set; }
        public string ModuleTaskDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }

        public int ProjectModuleId { get; set; }
        public virtual ProjectModule ProjectModule { get; set; }

        public virtual ICollection<TaskActivity> TaskActivities { get; set; }
        public virtual ICollection<ModuleTaskIssue> ModuleTaskIssues { get; set; }
    }

}
