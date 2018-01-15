using System.Collections.Generic;

namespace SwiftPMModel
{
    public class Unit
    {
        public int UnitId { get; set; }
        public int DepartmentId { get; set; }
        public string UnitName { get; set; }
        public string UnitCode { get; set; }
        public string UnitHead { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
        public virtual Department Department { get; set; }
    }
}
