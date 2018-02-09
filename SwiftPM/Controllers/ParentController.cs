
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SwiftPM.Models;
using SwiftPM.Models.ViewModels;
using SwiftPMModel;


namespace SwiftPM.Controllers
{
    public class ParentController : Controller
    {

        public SwiftPmDb db;
        public string UserId;
        public string FullName;
        public ParentVm parentVm;

        public ParentController ()
        {
            parentVm = new ParentVm();

            db = new SwiftPmDb();
            //UserId = parentVm.UserId = User.Identity.GetUserId();
            FullName = parentVm.FullName = "";
            //parentVm.FullName = 


           // public string UserId = User.Identity.GetUserId();
        }

        public void RegisterStaff(Staff staff)
        {
            
        }
    }
}