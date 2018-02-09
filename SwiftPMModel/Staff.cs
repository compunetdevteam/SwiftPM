using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwiftPMModel
{
    public class Staff : Person
    {
        public string StaffId { get; set; } 

        public string StaffCode { get; set; }
        
        public string Password { get; set; }
 
        public virtual ICollection<AssignedTask> AssignedTask { get; set; }


        // public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
