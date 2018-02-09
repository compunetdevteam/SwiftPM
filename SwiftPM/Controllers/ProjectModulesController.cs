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
    public class ProjectModulesController : Controller
    {
        private SwiftPmDb db = new SwiftPmDb();

        // GET: ProjectModules
        public async Task<ActionResult> Index()
        {
            var projectModules = db.ProjectModules.Include(p => p.Project);
            return View(await projectModules.ToListAsync());
        }

        // GET: ProjectModules/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModule projectModule = await db.ProjectModules.FindAsync(id);
            if (projectModule == null)
            {
                return HttpNotFound();
            }
            return View(projectModule);
        }

        // GET: ProjectModules/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: ProjectModules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProjectModule projectModule)
        {
            if (ModelState.IsValid)
            {
                db.ProjectModules.Add(projectModule);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", projectModule.ProjectId);
            return View(projectModule);
        }

        // GET: ProjectModules/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModule projectModule = await db.ProjectModules.FindAsync(id);
            if (projectModule == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", projectModule.ProjectId);
            return View(projectModule);
        }

        // POST: ProjectModules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProjectModuleId,ProjectId,ModuleName,PriorityLevel,ModulePercentage,DateAdded")] ProjectModule projectModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectModule).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", projectModule.ProjectId);
            return View(projectModule);
        }

        // GET: ProjectModules/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModule projectModule = await db.ProjectModules.FindAsync(id);
            if (projectModule == null)
            {
                return HttpNotFound();
            }
            return View(projectModule);
        }

        // POST: ProjectModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProjectModule projectModule = await db.ProjectModules.FindAsync(id);
            db.ProjectModules.Remove(projectModule);
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
