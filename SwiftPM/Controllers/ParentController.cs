
using System.Linq;
using System.Web.Mvc;
using SwiftPM.Models;
using SwiftPM.Models.ViewModels;
using SwiftPMModel;
using SwiftPM.Extensions;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

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

           // UserId = User.Identity.GetUserId();

           // FullName = parentVm.FullName= User.Identity.GetAppUserFullName();

        }

        public decimal ProjectCompletionRate(int id)
        {
            
            var totalTask = db.TaskActivities.Count(x=>x.ModuleTask.ProjectModuleId ==id);

            var completed = db.TaskActivities.Where(x=>x.ModuleTask.ProjectModuleId==id).Count(x => x.IsCompleted.Equals(true));

            decimal completedrate = (completed * 100) / 100;

            return completedrate;

        }

        //public async Task<ActionResult> LastesProjects(int number = 4)
        //{
        //    var lastest = db.ProjectModules.OrderByDescending(x => x.DateAdded).Select(x=> new { x.ModuleName , x.mo,x.ProjectDescription})
        //}



        //public string CompletionRate(string id)
        //{

        //}

    }
}