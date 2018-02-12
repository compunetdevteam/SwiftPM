using SwiftPM.Models;
using SwiftPMModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using SwiftPM.Extensions;

namespace SwiftPM.Controllers
{
    public class HomeController : ParentController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestPage()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult DashBoard(string userId)
        {
            var departmntId = User.Identity.GetUserDept();

            if (departmntId!=0)
            {

            }

            ViewBag.ProjCount = db.Projects.Count();
            ViewBag.ProjModulecount = db.ProjectModules.Count();

            ViewBag.DeptCount = db.Departments.Count();
            ViewBag.UnitCount = db.Units.Count();

            ViewBag.StaffCount = db.Staffs.Count();

            ViewBag.ModuleTaskCount = db.ModuleTasks.Count();
            ViewBag.ModuleTaskIssuesCount = db.ModuleTaskIssues.Count();

            ViewBag.AssignedTaskCount = db.AssignedTasks.Count();
            ViewBag.TaskActivityCount = db.TaskActivities.Count();
            ViewBag.CompletedTask = db.AssignedTasks.Select(c => c.CompletedDate != null).Count(); 

            return View();
        }

        public async Task<JsonResult> GetLatestProjModules()
        {
            var getLatestProj = await  db.Projects.OrderByDescending(x=>x.DateCreated).Select(x=> new { x.ProjectCode,x.ProjectName,x.PriorityLevel,x.DateCreated}).Take(5).ToListAsync();

            return Json(new { data = getLatestProj }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async  Task<ActionResult> Contact(Contact contact)
        {
            ViewBag.Success = "Successfully Posted";
            ViewBag.Failure = "Contact message not revieved, Pls try again. Thanks";
            return View();
        }

    }
}