using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SwiftPMModel
{
    public abstract class Person
    {

        public string Title { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string FullName
        {

            get { return FirstName + "" + LastName; }

        }

        public string Gender { get; set; }


        [DisplayName("Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }


        public string Email { get; set; }


        public string PhoneNumber { get; set; }


        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string StateOfOrigin { get; set; }

        public string MaritalStatus { get; set; }

        public bool Active { get; set; } = true;

        

        public byte[] Passport { get; set; }

        public string PassportUrl { get; set; }

        //public HttpPostedFileBase File
        //{
        //    get
        //    {
        //        return null;
        //    }

        //    set
        //    {
        //        try
        //        {
        //            var target = new MemoryStream();

        //            if (value.InputStream == null)
        //                return;

        //            value.InputStream.CopyTo(target);
        //            Passport = target.ToArray();
        //        }
        //        catch (Exception ex)
        //        {
        //            var message = ex.Message;
        //        }
        //    }
        //}


    }
}
