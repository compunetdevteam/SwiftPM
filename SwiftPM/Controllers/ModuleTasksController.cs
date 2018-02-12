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
    public class ModuleTasksController : Controller
    {
        private SwiftPmDb db = new SwiftPmDb();

        // GET: ModuleTasks
        public async Task<ActionResult> Index()
        {
            var moduleTasks = db.ModuleTasks.Include(m => m.ProjectModule);
            return View(await moduleTasks.ToListAsync());
        }

        // GET: ModuleTasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleTask moduleTask = await db.ModuleTasks.FindAsync(id);
            if (moduleTask == null)
            {
                return HttpNotFound();
            }
            return View(moduleTask);
        }

        // GET: ModuleTasks/Create
        public ActionResult Create()
        {
            ViewBag.ProjectModuleId = new SelectList(db.ProjectModules, "ProjectModuleId", "ModuleName");
            return View();
        }

        // POST: ModuleTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( ModuleTask moduleTask)
        {
            if (ModelState.IsValid)
            {
                db.ModuleTasks.Add(moduleTask);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectModuleId = new SelectList(db.ProjectModules, "ProjectModuleId", "ModuleName", moduleTask.ProjectModuleId);
            return View(moduleTask);
        }

        // GET: ModuleTasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleTask moduleTask = await db.ModuleTasks.FindAsync(id);
            if (moduleTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectModuleId = new SelectList(db.ProjectModules, "ProjectModuleId", "ModuleName", moduleTask.ProjectModuleId);
            return View(moduleTask);
        }

        // POST: ModuleTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( ModuleTask moduleTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleTask).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectModuleId = new SelectList(db.ProjectModules, "ProjectModuleId", "ModuleName", moduleTask.ProjectModuleId);
            return View(moduleTask);
        }

        // GET: ModuleTasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleTask moduleTask = await db.ModuleTasks.FindAsync(id);
            if (moduleTask == null)
            {
                return HttpNotFound();
            }
            return View(moduleTask);
        }

        // POST: ModuleTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ModuleTask moduleTask = await db.ModuleTasks.FindAsync(id);
            db.ModuleTasks.Remove(moduleTask);
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
