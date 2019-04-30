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
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            string sql = "Select * from students join Addresses on Addresses.Id = students.AddressId join Courses on Courses.Id = Students.CourseId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);
            return View(model);
        }

        ///SElf
        // GET: Students
        public ActionResult Report(string search, string sortBy)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "Name desc" : "";

            var std = db.Students.AsQueryable();

            var students = from s in db.Students
                           select s;

            if (!String.IsNullOrEmpty(search))
            {
                // students = students.Where(s => s.Courses.CourseName.Contains(search));
                std = std.Where(s => s.Courses.CourseName.Contains(search));
            }

            switch (sortBy)
            {
                default:
                    std = std.OrderBy(s => s.EnrollDate);
                    break;
            }
            return View(std.ToList());

            //return View(students.ToList());
        }



        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from students join Addresses on Addresses.Id = students.AddressId join Courses on Courses.Id = Students.CourseId where (students.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            string sql = "select * from Addresses";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Address().List(dt);
            ViewBag.AddressId = new SelectList(model, "Id", "Street");

            string sql1 = "select * from Courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new Course().List(dt1);
            ViewBag.CourseId = new SelectList(model1, "Id", "CourseName");

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Contact,Email,EnrollDate,AddressId,CourseId")] Student student)
        {
            string sql = "Insert into students (Name,Contact,Email,EnrollDate,AddressId,CourseId) values ('" + student.Name + "','" + student.Contact + "','" + student.Email + "','" + student.EnrollDate + "','" + student.AddressId + "','" + student.CourseId + "')";
            db.Insert(sql);
            return RedirectToAction("Index");
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql1 = "Select * from Addresses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new Address().List(dt1);
            ViewBag.AddressId = new SelectList(model1, "id", "Street");

            string sql2 = "select * from Courses";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new Course().List(dt2);
            ViewBag.CourseId = new SelectList(model2, "Id", "CourseName");

            string sql = "Select * from students  join Addresses on Addresses.Id = students.AddressId join Courses on Courses.Id = students.CourseId where (students.id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Contact,Email,EnrollDate,AddressId,CourseId")] Student student)
        {
            string sql = "Update students Set Name = '" + student.Name + "' , Contact = '" + student.Contact + "' , Email = '" + student.Email + "' , EnrollDate = '" + student.EnrollDate + "' , AddressId = '" + student.AddressId + "' , CourseId = '" + student.CourseId + "' where id = " + student.Id + "";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: Students/Delete/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from students join Addresses on Addresses.Id = students.AddressId join Courses on Courses.Id = students.CourseId where (students.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Student().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "Delete from students where id = " + id + "";
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
