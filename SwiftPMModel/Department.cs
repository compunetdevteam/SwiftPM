using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftPMModel
{
   public  class Department
    {
        public int DepartmentId { get; set; }
        public string DeptName { get; set; }

        public string DeptCode { get; set; }
        public string DepartmentHead { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
