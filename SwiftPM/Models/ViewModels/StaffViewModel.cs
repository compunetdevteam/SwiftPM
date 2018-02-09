using SwiftPMModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SwiftPM.Models.ViewModels
{
    public class CreateStaffVm
    {
        public DropDown.Title Title { get; set; }

        public string StaffCode { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public DropDown.MaritalStatus MaritalStatus { get; set; }

        public DropDown.Gender Gender { get; set; }





    }
    public class StaffSignUp
    {
       
    }
}