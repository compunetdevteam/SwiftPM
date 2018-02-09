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
    public class AssignedTasksController : ParentController
    {
        // private SwiftPmDb db = new SwiftPmDb();

        // GET: AssignedTasks
        public async Task<ActionResult> Index()
        {
            var assignedTasks = db.AssignedTasks.Include(a => a.Staff).Include(a => a.TaskActivity);
            return View(await assignedTasks.ToListAsync());
        }

        public async Task<ActionResult> GetIndex()
        {
            var data =  await db.AssignedTasks.Select(a => new { a.TaskActivity.ActivityName, a.AssignedBy, a.AssignedDate, a.ActivityState, a.Staff.FirstName }).ToListAsync();

            return Json(new { data= data}, JsonRequestBehavior.AllowGet );
        }

        public async Task<ActionResult> GetSatffTask()
        {
            var data = await db.AssignedTasks.AsNoTracking().Where(a => a.StaffId == UserId).Select(a => new { a.TaskActivity.ActivityName, a.AssignedDate, a.DueDate, a.AssignedBy }).ToListAsync();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

       

        // GET: AssignedTasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = await db.AssignedTasks.FindAsync(id);
           
            if (data == null)
            {
                ViewBag.Message = "No Task Details for the spscific task";
                return View("Index" ,new {message = ViewBag.Message });
            }
            return View(data);
        }
        public async Task<ActionResult> GetDetails(int? id)
        {
            if (id == null)
            {
                string msg = "No Details";
                return Json(new { data = msg }, JsonRequestBehavior.AllowGet);
            }
            var data = await db.AssignedTasks.FindAsync(id);

            if (data == null)
            {
                ViewBag.Message = "No Task Details for the specific task";
                return View("Index", new { message = ViewBag.Message });
            }
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        // GET: AssignedTasks/Create
        public ActionResult Create()
        {
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName");
            ViewBag.TaskActivityId = new SelectList(db.TaskActivities, "TaskActivityId", "ActivityName");
            return View();
        }

        // POST: AssignedTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AssignedTaskId,StaffId,TaskActivityId,AssignedDate,DueDate,TaskStatus,CompletedDate,ActivityState,AssignedBy,ApprovedBy")] AssignedTask assignedTask)
        {
            if (ModelState.IsValid)
            {
                db.AssignedTasks.Add(assignedTask);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName", assignedTask.StaffId);
            ViewBag.TaskActivityId = new SelectList(db.TaskActivities, "TaskActivityId", "ActivityName", assignedTask.TaskActivityId);
            return View(assignedTask);
        }

        // GET: AssignedTasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedTask assignedTask = await db.AssignedTasks.FindAsync(id);
            if (assignedTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName", assignedTask.StaffId);
            ViewBag.TaskActivityId = new SelectList(db.TaskActivities, "TaskActivityId", "ActivityName", assignedTask.TaskActivityId);
            return View(assignedTask);
        }

        // POST: AssignedTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AssignedTaskId,StaffId,TaskActivityId,AssignedDate,DueDate,TaskStatus,CompletedDate,ActivityState,AssignedBy,ApprovedBy")] AssignedTask assignedTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedTask).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName", assignedTask.StaffId);
            ViewBag.TaskActivityId = new SelectList(db.TaskActivities, "TaskActivityId", "ActivityName", assignedTask.TaskActivityId);
            return View(assignedTask);
        }

        // GET: AssignedTasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedTask assignedTask = await db.AssignedTasks.FindAsync(id);
            if (assignedTask == null)
            {
                return HttpNotFound();
            }
            return View(assignedTask);
        }

        // POST: AssignedTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AssignedTask assignedTask = await db.AssignedTasks.FindAsync(id);
            db.AssignedTasks.Remove(assignedTask);
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
