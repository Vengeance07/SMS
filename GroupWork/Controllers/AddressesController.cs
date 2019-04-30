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
    public class AddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Addresses
        public ActionResult Index()
        {
            string sql = "Select * from addresses";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Address().List(dt);
            return View(model);
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from addresses where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Address().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Street,City")] Address address)
        {
            if (ModelState.IsValid)
            {
                string sql = "Insert into addresses (Street,City) values ('" + address.Street + "','" + address.City + "')";
                db.Insert(sql);
                return RedirectToAction("Index");
            }

            return View(address);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql = "Select * from addresses where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Address().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Street,City")] Address address)
        {
            if (ModelState.IsValid)
            {
                string sql = "Update addresses set Street = '" + address.Street + "' , City = '" + address.City + "' where id = " + address.Id + "";
                db.Edit(sql);
                return RedirectToAction("Index");
            }
            return View(address);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from addresses where (id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Address().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "Delete from addresses where id = " + id + "";
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
