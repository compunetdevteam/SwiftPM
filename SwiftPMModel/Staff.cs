using System.Collections.Generic;

namespace SwiftPMModel
{
    public class Staff
    {
        public string StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<AssignedTask> AssignedTask { get; set; }

    }
}
