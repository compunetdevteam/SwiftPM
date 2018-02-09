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
    public class ModuleTaskIssuesController : Controller
    {
        private SwiftPmDb db = new SwiftPmDb();

        // GET: ModuleTaskIssues
        public async Task<ActionResult> Index()
        {
            var moduleTaskIssues = db.ModuleTaskIssues.Include(m => m.ModuleTask);
            return View(await moduleTaskIssues.ToListAsync());
        }

        // GET: ModuleTaskIssues/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleTaskIssue moduleTaskIssue = await db.ModuleTaskIssues.FindAsync(id);
            if (moduleTaskIssue == null)
            {
                return HttpNotFound();
            }
            return View(moduleTaskIssue);
        }

        // GET: ModuleTaskIssues/Create
        public ActionResult Create()
        {
            ViewBag.ModuleTaskId = new SelectList(db.ModuleTasks, "ModuleTaskId", "TaskName");
            return View();
        }

        // POST: ModuleTaskIssues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ModuleTaskIssueId,ModuleTaskId,IssueType,IssueDescription,DateSubmitted")] ModuleTaskIssue moduleTaskIssue)
        {
            if (ModelState.IsValid)
            {
                db.ModuleTaskIssues.Add(moduleTaskIssue);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ModuleTaskId = new SelectList(db.ModuleTasks, "ModuleTaskId", "TaskName", moduleTaskIssue.ModuleTaskId);
            return View(moduleTaskIssue);
        }

        // GET: ModuleTaskIssues/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleTaskIssue moduleTaskIssue = await db.ModuleTaskIssues.FindAsync(id);
            if (moduleTaskIssue == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuleTaskId = new SelectList(db.ModuleTasks, "ModuleTaskId", "TaskName", moduleTaskIssue.ModuleTaskId);
            return View(moduleTaskIssue);
        }

        // POST: ModuleTaskIssues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ModuleTaskIssueId,ModuleTaskId,IssueType,IssueDescription,DateSubmitted")] ModuleTaskIssue moduleTaskIssue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleTaskIssue).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ModuleTaskId = new SelectList(db.ModuleTasks, "ModuleTaskId", "TaskName", moduleTaskIssue.ModuleTaskId);
            return View(moduleTaskIssue);
        }

        // GET: ModuleTaskIssues/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleTaskIssue moduleTaskIssue = await db.ModuleTaskIssues.FindAsync(id);
            if (moduleTaskIssue == null)
            {
                return HttpNotFound();
            }
            return View(moduleTaskIssue);
        }

        // POST: ModuleTaskIssues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ModuleTaskIssue moduleTaskIssue = await db.ModuleTaskIssues.FindAsync(id);
            db.ModuleTaskIssues.Remove(moduleTaskIssue);
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
