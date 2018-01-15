using System;
using System.Collections.Generic;

namespace SwiftPMModel
{
    public class ModuleTask
    {
        public int ModuleTaskId { get; set; }
        public int ProjectModuleId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public virtual ProjectModule ProjectModule { get; set; }
        public virtual ICollection<TaskActivity> TaskActivities { get; set; }
        public virtual ICollection<ModuleTaskIssue> ModuleTaskIssues { get; set; }
    }

}
