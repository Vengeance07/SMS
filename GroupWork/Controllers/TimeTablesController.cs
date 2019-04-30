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
    
    public class TimeTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeTables
        public ActionResult Index()
        {
            string sql = "Select * from TimeTables join Courses on Courses.Id = TimeTables.CourseId join Teachers on Teachers.Id = TimeTables.TeacherId join Modules on Modules.Id = TimeTables.ModuleId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new TimeTable().List(dt);
            return View(model);
        }

        // GET: TimeTables/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from TimeTables join Courses on Courses.Id = TimeTables.CourseId join Teachers on Teachers.Id = TimeTables.TeacherId join Modules on Modules.Id = TimeTables.ModuleId where (TimeTables.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new TimeTable().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: TimeTables/Create
        public ActionResult Create()
        {
            string sql1 = "Select * from Courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new Course().List(dt1);
            ViewBag.CourseId = new SelectList(model1, "Id", "CourseName");

            string sql2 = "Select * from Modules";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new Module().List(dt2);
            ViewBag.ModuleId = new SelectList(model2, "Id", "ModuleName");

            string sql3 = "Select * from Teachers";
            db.List(sql3);
            var dt3 = db.List(sql3);
            var model3 = new Teacher().List(dt3);
            ViewBag.TeacherId = new SelectList(model3, "Id", "TeacherName");

            return View();
        }

        // POST: TimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,TeacherId,ModuleId,StartTime,EndTime,Day")] TimeTable timeTable)
        {
            string sql = "Insert into TimeTables (CourseId,TeacherId,ModuleId,StartTime,EndTime,Day) values ('" + timeTable.CourseId + "','" + timeTable.TeacherId + "','" + timeTable.ModuleId + "','" + timeTable.StartTime + "','" + timeTable.EndTime + "','" + timeTable.Day + "')";
            db.Insert(sql);
            return RedirectToAction("Index");
        }

        // GET: TimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql1 = "Select * from Courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new Course().List(dt1);
            ViewBag.CourseId = new SelectList(model1, "Id", "CourseName");

            string sql2 = "Select * from Modules";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new Module().List(dt2);
            ViewBag.ModuleId = new SelectList(model2, "Id", "ModuleName");

            string sql3 = "Select * from Teachers";
            db.List(sql3);
            var dt3 = db.List(sql3);
            var model3 = new Teacher().List(dt3);
            ViewBag.TeacherId = new SelectList(model3, "Id", "TeacherName");

            string sql = "Select * from TimeTables join Courses on Courses.Id = TimeTables.CourseId join Teachers on Teachers.Id = TimeTables.TeacherId join Modules on Modules.Id = TimeTables.ModuleId where (TimeTables.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new TimeTable().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,TeacherId,ModuleId,StartTime,EndTime,Day")] TimeTable timeTable)
        {
            string sql = "Update TimeTables Set CourseId = '" + timeTable.CourseId + "' , TeacherId = '" + timeTable.TeacherId + "' , ModuleId = '" + timeTable.ModuleId + "', StartTime = '" + timeTable.StartTime + "' , EndTime = '" + timeTable.EndTime + "', Day = '" + timeTable.Day + "' where id = " + timeTable.Id + "";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: TimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from TimeTables join Courses on Courses.Id = TimeTables.CourseId join Teachers on Teachers.Id = TimeTables.TeacherId join Modules on Modules.Id = TimeTables.ModuleId where (TimeTables.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new TimeTable().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "Delete from TimeTables where id = " + id + "";
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
