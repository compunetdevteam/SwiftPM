using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SwiftPMModel
{
    public class AssignStaffToDept
    {
        public int AssignStaffToDeptId { get; set; }

        //[NotMapped]
        //public DropDown.Role RolesDropDown { get; set; }
        //public string StaffRole { get; set; }

        public string StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Departments { get; set; }

        public DateTime DateOfAssignment { get; set; } = DateTime.Now;
    }

   
}
