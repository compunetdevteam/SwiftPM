using SwiftPMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftPM.Models.ViewModels
{
    public class AssignDepartmentVm
    {
        public DropDown.Role RolesDropDown { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }

        public  virtual ICollection<Department> Department { get; set; }
    }
}