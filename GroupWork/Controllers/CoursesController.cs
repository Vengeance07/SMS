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
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            string sql = "Select * from courses";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt);
            return View(model);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from courses where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseName")] Course course)
        {
            if (ModelState.IsValid)
            {
                string sql = "Insert into courses (CourseName) values ('" + course.CourseName + "')";
                db.Insert(sql);
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql = "Select * from courses where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseName")] Course course)
        {
            if (ModelState.IsValid)
            {
                string sql = "Update courses set CourseName = '" + course.CourseName + "' where id = " + course.Id + "";
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from courses where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "Delete from courses where id = " + id + "";
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
