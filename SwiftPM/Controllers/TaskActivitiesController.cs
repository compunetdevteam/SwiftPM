using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SwiftPM.Models;
using SwiftPMModel;

namespace SwiftPM.Controllers
{
    public class TaskActivitiesController : Controller
    {
        private SwiftPmDb db = new SwiftPmDb();

        // GET: TaskActivities
        public async Task<ActionResult> Index()
        {
            var taskActivities = db.TaskActivities.Include(t => t.ModuleTask);
            return View(await taskActivities.ToListAsync());
        }

        public async Task<ActionResult> GetTasks()
        {
            var data = await  db.TaskActivities.AsNoTracking().Select(t =>  new {t.ModuleTask.ModuleTaskName, t.ActivityName, t.CreatedDate, t.DueDate }).ToListAsync();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);

        }


        // GET: TaskActivities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskActivity taskActivity = await db.TaskActivities.FindAsync(id);
            if (taskActivity == null)
            {
                return HttpNotFound();
            }
            return View(taskActivity);
        }

        // GET: TaskActivities/Create
        public ActionResult Create()
        {
            ViewBag.ModuleTaskId = new SelectList(db.ModuleTasks, "ModuleTaskId", "TaskName");
            return View();
        }

        // POST: TaskActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TaskActivityId,ModuleTaskId,ActivityName,CreatedDate,DueDate")] TaskActivity taskActivity)
        {
            if (ModelState.IsValid)
            {
                db.TaskActivities.Add(taskActivity);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ModuleTaskId = new SelectList(db.ModuleTasks, "ModuleTaskId", "TaskName", taskActivity.ModuleTaskId);
            return View(taskActivity);
        }

        // GET: TaskActivities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskActivity taskActivity = await db.TaskActivities.FindAsync(id);
            if (taskActivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuleTaskId = new SelectList(db.ModuleTasks, "ModuleTaskId", "TaskName", taskActivity.ModuleTaskId);
            return View(taskActivity);
        }

        // POST: TaskActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TaskActivityId,ModuleTaskId,ActivityName,CreatedDate,DueDate")] TaskActivity taskActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskActivity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ModuleTaskId = new SelectList(db.ModuleTasks, "ModuleTaskId", "TaskName", taskActivity.ModuleTaskId);
            return View(taskActivity);
        }

        // GET: TaskActivities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskActivity taskActivity = await db.TaskActivities.FindAsync(id);
            if (taskActivity == null)
            {
                return HttpNotFound();
            }
            return View(taskActivity);
        }

        // POST: TaskActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TaskActivity taskActivity = await db.TaskActivities.FindAsync(id);
            db.TaskActivities.Remove(taskActivity);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
