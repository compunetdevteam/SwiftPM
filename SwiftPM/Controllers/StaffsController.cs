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
using SwiftPM.Models.ViewModels;
using static SwiftPMModel.DropDown;
using SwiftPM.Extensions;
using Microsoft.AspNet.Identity;

namespace SwiftPM.Controllers
{
    public class StaffsController : ParentController
    {
        // private SwiftPmDb db = new SwiftPmDb();

        public int DepartId ;                                  

        public async Task<ActionResult> Index()
        {
            return View(await db.Staffs.ToListAsync());
        }


        public async Task<JsonResult> GetIndex()
        {
            var dataContent = await db.Staffs.ToListAsync();

            if (dataContent.Any())
            {
                var collect = dataContent.Select(x => new { x.Title,x.FirstName, x.LastName, x.StaffCode });
                return Json(new { data = dataContent }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
        }


        // Get all staffs in the department of the HOD or Director

        //[Authorize(Roles ="HOD")]
        public async Task<JsonResult> GetDepartmentalStaffs()
        {
            var data = await db.AssignStaffToDepts.Where(x=>x.DepartmentId == User.Identity.GetUserDept()).Select(x => new {
                x.Staff.FirstName,
                x.Staff.LastName,
                x.Staff.StaffCode,
                x.Staff.Email
            }).ToListAsync();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DepartmentalStaffs(int? DeptId)
        {
            if (DeptId!= 2 || DeptId !=0)
            {              
                ViewBag.Message = "List Of all staffs in your department;";
                return View();
            }
          
            ViewBag.Message = "You have not been assigned to a department . Consult the Human Resource;";
            return View();
        }




        // GET: Staffs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = await db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateStaffVm staff)
        {
            Random random = new Random();
            string staffCode = ("COM"+random.Next(1, 99999));

            if (ModelState.IsValid)
            {
                try
                {
                    // staff.StaffId = staffCode.ToString();
                    Staff newStaff = new Staff()
                    {
                        StaffId = staffCode,
                        StaffCode = (staff.FirstName + staffCode).ToUpper(),
                        FirstName = staff.FirstName,
                        LastName = staff.LastName,
                        Title = staff.Title.ToString(),
                        MaritalStatus = staff.MaritalStatus.ToString(),
                        Gender= staff.Gender.ToString(),
                                               
                        PhoneNumber = staff.PhoneNumber,                      
                    };         

                    db.Staffs.Add(newStaff);
                }
                catch
                {
                    ViewBag.Message = "Staff Creation was not successful"; 
                }

                await db.SaveChangesAsync();
                return RedirectToAction ("Index");
            }

            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Staff staff = await db.Staffs.FindAsync(id);

            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = await db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Staff staff = await db.Staffs.FindAsync(id);
            db.Staffs.Remove(staff);
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
