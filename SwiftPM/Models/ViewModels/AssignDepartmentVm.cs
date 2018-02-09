using SwiftPMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftPM.Models.ViewModels
{
    public class AssignDepartmentVm
    {
        public Staff Staff { get; set; }

        public Department Department { get; set; }
    }
}