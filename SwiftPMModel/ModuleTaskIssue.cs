using System;

namespace SwiftPMModel
{
    public class ModuleTaskIssue
    {
        public int ModuleTaskIssueId { get; set; }
        public int ModuleTaskId { get; set; }

        public string IssueType { get; set; }
        public string IssueDescription { get; set; }
        public DateTime DateSubmitted { get; set; }
        public virtual ModuleTask ModuleTask { get; set; }
    }
}
