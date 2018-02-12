using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftPMModel
{
    public class Organization
    {
        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public string RCNumber { get; set; }

        public string Slogan { get; set; }

        [Phone]
        public string ConpanyLine { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string  ConatctPersonFisrtName { get; set; }

        public string ContactPersonLastName { get; set; }

        [ScaffoldColumn(false)]
        public string CEOFullName { get; set; }

        public DateTime DateCreated { get; set; }

        public bool Active { get; set; } = true;

        public virtual ICollection<Staff>  Staffs { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

    }

    public class CEO :Person
    {
        public string CEOId { get; set; }

        
    }
}
