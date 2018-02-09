using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftPMModel
{
    public class AssignStaffToDept
    {
        public int AssignStaffToDeptId { get; set; }

        public string StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public DateTime DateOfAssignment { get; set; }
    }

   
}
