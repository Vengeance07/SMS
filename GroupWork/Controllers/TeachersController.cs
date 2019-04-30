using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupWork.Models;

namespace GroupWork.Controllers
{
    public class TeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teachers
        
        public ActionResult Index()
        {
            string sql = "Select * from Teachers join Addresses on Addresses.Id = Teachers.AddressId join ModuleTypes on ModuleTypes.Id = Teachers.ModuleTypeId join Modules on Modules.Id = Teachers.ModuleId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Teacher().List(dt);
            return View(model);
        }

        ///SElf
        // GET: Teachers
        public ActionResult Report(string search)
        {
            //ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";

            var tea = db.Teachers.AsQueryable();

            var teachers = from s in db.Teachers
                           select s;

            if (!String.IsNullOrEmpty(search))
            {
               // teachers = teachers.Where(s => s.Modules.ModuleName.Contains(search));
                tea = tea.Where(s => s.Modules.ModuleName.Contains(search));
            }

           
           return View(tea.ToList());

           // return View(teachers.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from Teachers join Addresses on Addresses.Id = Teachers.AddressId join ModuleTypes on ModuleTypes.Id = Teachers.ModuleTypeId join Modules on Modules.Id = Teachers.ModuleId where (Teachers.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Teacher().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            string sql1 = "Select * from Addresses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new Address().List(dt1);
            ViewBag.AddressId = new SelectList(model1, "Id", "Street");

            string sql2 = "Select * from Modules";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new Module().List(dt2);
            ViewBag.ModuleId = new SelectList(model2, "Id", "ModuleName");

            string sql3 = "Select * from ModuleTypes";
            db.List(sql3);
            var dt3 = db.List(sql3);
            var model3 = new ModuleType().List(dt3);
            ViewBag.ModuleTypeId = new SelectList(model3, "Id", "ModuleTypeName");
           
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeacherName,Contact,Email,AddressId,ModuleTypeId,ModuleId")] Teacher teacher)
        {
            string sql = "Insert into Teachers (TeacherName,Contact,Email,AddressId,ModuleTypeId,ModuleId) values ('" + teacher.TeacherName + "','" + teacher.Contact + "','" + teacher.Email + "','" + teacher.AddressId + "','" + teacher.ModuleTypeId + "','" + teacher.ModuleId + "')";
            db.Insert(sql);
            return RedirectToAction("Index");
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql1 = "Select * from Addresses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new Address().List(dt1);
            ViewBag.AddressId = new SelectList(model1, "Id", "Street");

            string sql2 = "Select * from Modules";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new Module().List(dt2);
            ViewBag.ModuleId = new SelectList(model2, "Id", "ModuleName");

            string sql3 = "Select * from ModuleTypes";
            db.List(sql3);
            var dt3 = db.List(sql3);
            var model3 = new ModuleType().List(dt3);
            ViewBag.ModuleTypeId = new SelectList(model3, "Id", "ModuleTypeName");

            string sql = "Select * from Teachers join Addresses on Addresses.Id = Teachers.AddressId join ModuleTypes on ModuleTypes.Id = Teachers.ModuleTypeId join Modules on Modules.Id = Teachers.ModuleId where (Teachers.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Teacher().List(dt);
            return View(model.FirstOrDefault());

        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeacherName,Contact,Email,AddressId,ModuleTypeId,ModuleId")] Teacher teacher)
        {
            string sql = "Update Teachers Set TeacherName = '" + teacher.TeacherName + "' , Contact = '" + teacher.Contact + "' , Email = '" + teacher.Email + "', AddressId = '" + teacher.AddressId + "' , ModuleTypeId = '" + teacher.ModuleTypeId + "', ModuleId = '" + teacher.ModuleId + "' where id = " + teacher.Id + "";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: Teachers/Delete/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from Teachers join Addresses on Addresses.Id = Teachers.AddressId join ModuleTypes on ModuleTypes.Id = Teachers.ModuleTypeId join Modules on Modules.Id = Teachers.ModuleId where (Teachers.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Teacher().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "Delete from Teachers where id = " + id + "";
            db.Delete(sql);
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
