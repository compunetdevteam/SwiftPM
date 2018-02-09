using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using SwiftPMModel;
using SwiftPM.Models;

namespace SwiftPM.Extensions
{
    public static  class ClaimsExtensions
    {
            static string GetUserEmail(this ClaimsIdentity identity)
            {
                return identity.Claims?.FirstOrDefault(c => c.Type == "SwiftPM.Models.StaffEdit.Email")?.Value;
            }

            public static string GetUserEmail(this IIdentity identity)
            {
                var claimsIdentity = identity as ClaimsIdentity;
                return claimsIdentity != null ? GetUserEmail(claimsIdentity) : "";
            }


            public static string GetAppUserFirstName( this IIdentity identity)
            {
                 SwiftPmDb db = new SwiftPmDb();

                var userId = identity.GetUserId();
                var firstName = db.Users.FirstOrDefault(u => u.Id == userId)?.FirstName;
                return firstName;
            }

        }
    }
