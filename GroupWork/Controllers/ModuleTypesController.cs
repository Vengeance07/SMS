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
    public class ModuleTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ModuleTypes
        public ActionResult Index()
        {
            string sql = "Select * from ModuleTypes";
            db.List(sql);
            var dt = db.List(sql);
            var model = new ModuleType().List(dt);
            return View(model);
        }

        // GET: ModuleTypes/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from ModuleTypes where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new ModuleType().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: ModuleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModuleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ModuleTypeName")] ModuleType moduleType)
        {
            if (ModelState.IsValid)
            {
                string sql = "Insert into ModuleTypes (ModuleTypeName) values ('" + moduleType.ModuleTypeName + "')";
                db.Insert(sql);
                return RedirectToAction("Index");
            }

            return View(moduleType);
        }

        // GET: ModuleTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql = "Select * from ModuleTypes where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new ModuleType().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: ModuleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ModuleTypeName")] ModuleType moduleType)
        {
            if (ModelState.IsValid)
            {
                string sql = "Update ModuleTypes set ModuleTypeName = '" + moduleType.ModuleTypeName + "' where id = " + moduleType.Id + "";
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(moduleType);
        }

        // GET: ModuleTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from ModuleTypes where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new ModuleType().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: ModuleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "Delete from ModuleTypes where id = " + id + "";
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
