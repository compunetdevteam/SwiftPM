using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftPMModel
{
    public class AssignProjectDept
    {
        public int AssignProjectDeptId { get; set; }

        public virtual Project Project { get; set; }

        public ICollection<Department> Department { get; set; }
    }
}
