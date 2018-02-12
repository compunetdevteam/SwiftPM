using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using SwiftPMModel;
using SwiftPM.Models;
using static SwiftPMModel.DropDown;

namespace SwiftPM.Extensions
{
    public static  class ClaimsExtensions 

    {       private readonly static SwiftPmDb db = new SwiftPmDb();
            
            public static string UserId(this IIdentity identity)
            {
                var userId = identity.GetUserId();
                
                 return userId;
            }
             
            public static string GetUserEmail(this IIdentity identity)
            {
                var userId = identity.GetUserId();
                var email = db.Staffs.FirstOrDefault(u => u.StaffId == userId)?.Email;
                 if (email.Any()) { return email; }
                 return "";
            }

            public static string GetAppUserFirstName( this IIdentity identity)
            {
                var userId = identity.GetUserId();
                var firstName = db.Users.FirstOrDefault(u => u.Id == userId)?.FirstName;
                 if (firstName.Any()) { return firstName; }
                 return "";
            }
            public static string GetAppUserFullName(this IIdentity identity)
            {
            
                var userId = identity.GetUserId();
                var fullName = db.Staffs.FirstOrDefault(u => u.StaffId == userId)?.FullName;
                if (fullName.Any()) { return fullName; }

                return "";
            }

          public static int GetUserDept(this IIdentity identity)
          {
            var userId = identity.GetUserId();

            var userDeptId = db.AssignStaffToDepts.AsNoTracking().Where(a => a.StaffId == userId);
            if (userDeptId.Any())
            {
               int deptId = userDeptId.First().DepartmentId;
                return deptId;
            }

            return 0;
        }

     
    }
    }
