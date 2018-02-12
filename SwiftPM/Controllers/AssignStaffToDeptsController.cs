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
using Microsoft.AspNet.Identity.Owin;

namespace SwiftPM.Controllers
{
    public class AssignStaffToDeptsController : ParentController
    {
       // private SwiftPmDb db = new SwiftPmDb();
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: AssignStaffToDepts
        public async Task<ActionResult> Index()
        {
            var assignStaffToDepts =  db.AssignStaffToDepts.ToListAsync();
            return View(await assignStaffToDepts);
        }
        public async Task<JsonResult> AllAssignedIndex()
        {
            var data = await db.AssignStaffToDepts.Select(x => new {
                x.Staff.FirstName,
                x.Staff.LastName,
                x.Staff.StaffCode,
                x.Departments,            
                x.DateOfAssignment,
            }).ToListAsync();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> NonAssingedIndex()
        {
            var data = await db.Staffs.Select(x => new {
                x.FirstName,
                x.LastName,
                x.StaffCode,
                x.IsAssigned,
                
            }).Where(x=>x.IsAssigned==false).ToListAsync();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        // GET: AssignStaffToDepts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignStaffToDept assignStaffToDept = await db.AssignStaffToDepts.FindAsync(id);
            if (assignStaffToDept == null)
            {
                return HttpNotFound();
            }
            return View(assignStaffToDept);
        }

        // GET: AssignStaffToDepts/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DeptName");
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FullName");
            return View();
        }
     

        // POST: AssignStaffToDepts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( AssignStaffToDept assignStaffToDept)
        {
            if (ModelState.IsValid)
            {
                              
                db.AssignStaffToDepts.Add(assignStaffToDept);
               
              // bool hasbeenAssigned = db.Staffs.FirstOrDefault(x => x.StaffId.Equals(assignStaffToDept.StaffId)).IsAssigned;

                Staff staff = db.Staffs.Find(assignStaffToDept.StaffId);
                staff.IsAssigned = true;
               
                db.Entry(assignStaffToDept).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DeptName", assignStaffToDept.DepartmentId);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FullName", assignStaffToDept.StaffId);
            return View(assignStaffToDept);
        }

        // GET: AssignStaffToDepts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignStaffToDept assignStaffToDept = await db.AssignStaffToDepts.FindAsync(id);
            if (assignStaffToDept == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DeptName", assignStaffToDept.DepartmentId);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FullName", assignStaffToDept.StaffId);
            return View(assignStaffToDept);
        }

        // POST: AssignStaffToDepts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AssignStaffToDept assignStaffToDept)
        {
            if (ModelState.IsValid)
            {
               
                Staff staff = db.Staffs.Find(assignStaffToDept.StaffId);
                staff.IsAssigned = true;


                db.Entry(assignStaffToDept).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DeptName", assignStaffToDept.DepartmentId);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FullName", assignStaffToDept.StaffId);
            return View(assignStaffToDept);
        }

        // GET: AssignStaffToDepts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignStaffToDept assignStaffToDept = await db.AssignStaffToDepts.FindAsync(id);
            if (assignStaffToDept == null)
            {
                return HttpNotFound();
            }
            return View(assignStaffToDept);
        }

        // POST: AssignStaffToDepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AssignStaffToDept assignStaffToDept = await db.AssignStaffToDepts.FindAsync(id);
            db.AssignStaffToDepts.Remove(assignStaffToDept);
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
