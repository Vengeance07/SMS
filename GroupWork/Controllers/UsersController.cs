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
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            string sql = "select Id, Email, PasswordHash, PhoneNumber from AspNetUsers";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Users().List(dt);
            return View(model);

        }
      

        // GET: Users/Edit/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            return RedirectToAction("Index");
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,PasswordHash,PhoneNumber")] Users users)
        {
            string sql = "Update AspNetUsers Set Email = '" + users.Email + "' , PasswordHash = '" + users.PasswordHash + "' , PhoneNumber = '" + users.PhoneNumber + "' where id = " + users.Id + "";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: Users/Delete/5
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            return RedirectToAction("Index");
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Users users = db.Users.Find(id);
            //db.Users.Remove(users);
            db.SaveChanges();
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
