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
    public class ModulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Modules
        public ActionResult Index()
        {
            string sql = "Select * from modules join courses on courses.Id = modules.CourseId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Module().List(dt);
            return View(model);
        }

        // GET: Modules/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from modules join courses on courses.id = modules.CourseId where (modules.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Module().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            string sql = "Select * from courses";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Course().List(dt);
            ViewBag.CourseId = new SelectList(model, "Id", "CourseName");
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ModuleName,CourseId")] Module module)
        {
            string sql = "Insert into Modules (CourseId, ModuleName) values ('" + module.CourseId + "' ,'" + module.ModuleName + "' )";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql = "Select * from Modules join Courses on Courses.Id = Modules.CourseId where (Modules.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Module().List(dt);

            string sql1 = "Select * from courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new Course().List(dt1);
            ViewBag.CourseId = new SelectList(model1, "Id", "CourseName");

            return View(model.FirstOrDefault());
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ModuleName,CourseId")] Module module)
        {
            string sql = "Update Modules Set ModuleName = '" + module.ModuleName + "' , courseId = '" + module.CourseId + "' where id = " + module.Id + "";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: Modules/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from Modules join Courses on Courses.Id = Modules.CourseId where (Modules.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Module().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "Delete from Modules where id = " + id + "";
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
