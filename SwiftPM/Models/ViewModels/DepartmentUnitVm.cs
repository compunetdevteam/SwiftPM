using SwiftPMModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftPM.Models.ViewModels
{
    public class DepartmentUnitVm
    {
        public int DepartmentUnitId { get; set; }
        public Department Department { get; set; }

        public Unit Unit { get; set; }

        
    }
}