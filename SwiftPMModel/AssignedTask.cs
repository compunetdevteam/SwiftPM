using System;

namespace SwiftPMModel
{
    public class AssignedTask
    {
        public int AssignedTaskId { get; set; }
        public string StaffId { get; set; }
        public int TaskActivityId { get; set; }
        public DateTime AssignedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string TaskStatus { get; set; }

        public DateTime? CompletedDate
        {
            get
            {
                if (ActivityState.Equals("Completed"))
                {
                    return DateTime.Now;
                }
                return null;
            }
            set { }
        }
        public string ActivityState { get; set; }
        public string AssignedBy { get; set; }

        public string ApprovedBy { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual TaskActivity TaskActivity { get; set; }

    }
}
