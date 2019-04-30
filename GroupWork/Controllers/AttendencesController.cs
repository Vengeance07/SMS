using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupWork.Models;
using System.Globalization;

namespace GroupWork.Controllers
{
    public class AttendencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attendences
        public ActionResult Index()
        {
            string sql = "Select * from Attendences join Teachers on Teachers.Id = Attendences.TeacherId join Courses on Courses.Id = Attendences.CourseId join ModuleTypes on ModuleTypes.Id = Attendences.ModuleTypeId join Students on Students.Id = Attendences.StudentId join TimeTables on TimeTables.Id = Attendences.TimeTableId";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Attendence().List(dt);
            return View(model);
        }

        // GET: Attendences/Details/5
        public ActionResult Details(int? id)
        {
            string sql = "Select * from Attendences join Teachers on Teachers.Id = Attendences.TeacherId join Courses on Courses.Id = Attendences.CourseId join ModuleTypes on ModuleTypes.Id = Attendences.ModuleTypeId join Students on Students.Id = Attendences.StudentId join TimeTables on TimeTables.Id = Attendences.TimeTableId where (Attendences.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Attendence().List(dt);
            return View(model.FirstOrDefault());
        }

        // GET: Attendences/Create
        public ActionResult Create()
        {
            string sql1 = "Select * from Courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new Course().List(dt1);
            ViewBag.CourseId = new SelectList(model1, "Id", "CourseName");

            string sql2 = "Select * from ModuleTypes";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new ModuleType().List(dt2);
            ViewBag.ModuleTypeId = new SelectList(model2, "Id", "ModuleTypeName");

            string sql3 = "Select * from Students";
            db.List(sql3);
            var dt3 = db.List(sql3);
            var model3 = new Student().List(dt3);
            ViewBag.StudentId = new SelectList(model3, "Id", "Name");

            string sql4 = "Select * from Teachers";
            db.List(sql4);
            var dt4 = db.List(sql4);
            var model4 = new Teacher().List(dt4);
            ViewBag.TeacherId = new SelectList(model4, "Id", "TeacherName");

            string sql5 = "Select * from TimeTables";
            db.List(sql5);
            var dt5 = db.List(sql5);
            var model5 = new TimeTable().List(dt5);
            ViewBag.TimeTableId = new SelectList(model5, "Id", "Day");
            return View();
        }

        // POST: Attendences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeacherId,CourseId,ModuleTypeId,StudentId,TimeTableId,Date,Status")] Attendence attendence)
        {
            string sql = "Insert into Attendences (TeacherId,CourseId,ModuleTypeId,StudentId,TimeTableId,Date,Status) values ('" + attendence.TeacherId + "','" + attendence.CourseId + "','" + attendence.ModuleTypeId + "','" + attendence.StudentId + "','" + attendence.TimeTableId + "','" + attendence.Date + "','" + attendence.Status + "')";
            db.Insert(sql);
            return RedirectToAction("Index");
        }

        // GET: Attendences/Edit/5
        public ActionResult Edit(int? id)
        {
            string sql1 = "Select * from Courses";
            db.List(sql1);
            var dt1 = db.List(sql1);
            var model1 = new Course().List(dt1);
            ViewBag.CourseId = new SelectList(model1, "Id", "CourseName");

            string sql2 = "Select * from ModuleTypes";
            db.List(sql2);
            var dt2 = db.List(sql2);
            var model2 = new ModuleType().List(dt2);
            ViewBag.ModuleTypeId = new SelectList(model2, "Id", "ModuleTypeName");

            string sql3 = "Select * from Students";
            db.List(sql3);
            var dt3 = db.List(sql3);
            var model3 = new Student().List(dt3);
            ViewBag.StudentId = new SelectList(model3, "Id", "Name");

            string sql4 = "Select * from Teachers";
            db.List(sql4);
            var dt4 = db.List(sql4);
            var model4 = new Teacher().List(dt4);
            ViewBag.TeacherId = new SelectList(model4, "Id", "TeacherName");

            string sql5 = "Select * from TimeTables";
            db.List(sql5);
            var dt5 = db.List(sql5);
            var model5 = new TimeTable().List(dt5);
            ViewBag.TimeTableId = new SelectList(model5, "Id", "Day");

            string sql = "Select * from Attendences join Teachers on Teachers.Id = Attendences.TeacherId join Courses on Courses.Id = Attendences.CourseId join ModuleTypes on ModuleTypes.Id = Attendences.ModuleTypeId join Students on Students.Id = Attendences.StudentId join TimeTables on TimeTables.Id = Attendences.TimeTableId where (Attendences.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Attendence().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: Attendences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeacherId,CourseId,ModuleTypeId,StudentId,TimeTableId,Date,Status")] Attendence attendence)
        {
            string sql = "Update Attendences Set TeacherId = '" + attendence.TeacherId + "' , CourseId = '" + attendence.CourseId + "' , ModuleTypeId = '" + attendence.ModuleTypeId + "' , StudentId = '" + attendence.StudentId + "' , TimeTableId = '" + attendence.TimeTableId + "' , Date = '" + attendence.Date + "' , Status = '" + attendence.Status + "' where id = " + attendence.Id + "";
            db.Edit(sql);
            return RedirectToAction("Index");
        }

        // GET: Attendences/Delete/5
        public ActionResult Delete(int? id)
        {
            string sql = "Select * from Attendences join Teachers on Teachers.Id = Attendences.TeacherId join Courses on Courses.Id = Attendences.CourseId join ModuleTypes on ModuleTypes.Id = Attendences.ModuleTypeId join Students on Students.Id = Attendences.StudentId join TimeTables on TimeTables.Id = Attendences.TimeTableId where (Attendences.Id = " + id + ")";
            db.List(sql);
            var dt = db.List(sql);
            var model = new Attendence().List(dt);
            return View(model.FirstOrDefault());
        }

        // POST: Attendences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string sql = "Delete from Attendences where id = " + id + "";
            db.Delete(sql);
            return RedirectToAction("Index");
        }

        public ActionResult Absent()
        {
            var dateTime = DateTime.Now.ToString("dd/MM/yyyy");
            //ateTime.Now.ToString("MM/dd/yyyy")
            //var weekStart = dateTime.AddDays(-(int)dateTime.DayOfWeek);
            //var weekEnd = weekStart.AddDays(7).AddSeconds(-1);

            string sql = "Select * from Attendences join Teachers on Teachers.Id = Attendences.TeacherId join Courses on Courses.Id = Attendences.CourseId join ModuleTypes on ModuleTypes.Id = Attendences.ModuleTypeId join Students on Students.Id = Attendences.StudentId join TimeTables on TimeTables.Id = Attendences.TimeTableId where Attendences.Status = 'A' AND Attendences.Date = '" + dateTime + "'";
            var dt = db.List(sql);
            var model = new Attendence().List(dt);
            return View(model);
        }
        public ActionResult Weeklystudent(int? StudentId)
        {

            var dateTime = DateTime.Now;
            int year = dateTime.Date.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            CultureInfo cul = CultureInfo.CurrentCulture;
            int week = cul.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int days = (week - 1) * 7;
            DateTime dt = firstDay.AddDays(days);
            DayOfWeek dayWeek = dt.DayOfWeek;
            DateTime startWeek = dt.AddDays(-(int)dayWeek);
            DateTime endWeek = startWeek.AddDays(6);

            string sql = "Select * from Attendences join Teachers on Teachers.Id = Attendences.TeacherId join Courses on Courses.Id = Attendences.CourseId join ModuleTypes on ModuleTypes.Id = Attendences.ModuleTypeId join Students on Students.Id = Attendences.StudentId join TimeTables on TimeTables.Id = Attendences.TimeTableId"; //where Students.Id = '" + StudentId + "' AND Attendences.Date BETWEEN '" + startWeek.ToString("dd/MM/yyyy") + "' and '" + endWeek.ToString("dd/MM/yyyy") + "'
            db.List(sql);
            var dt1 = db.List(sql);
            var model = new Attendence().List(dt1);
            return View(model);

        }
        public ActionResult Weekly()
        {
            var dateTime = DateTime.Now;
            int year = dateTime.Date.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            CultureInfo cul = CultureInfo.CurrentCulture;
            int week = cul.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int days = (week - 1) * 7;
            DateTime dt = firstDay.AddDays(days);
            DayOfWeek dayWeek = dt.DayOfWeek;
            DateTime startWeek = dt.AddDays(-(int)dayWeek);
            DateTime endWeek = startWeek.AddDays(6);

            string sql = "Select * from Attendences join Teachers on Teachers.Id = Attendences.TeacherId join Courses on Courses.Id = Attendences.CourseId join ModuleTypes on ModuleTypes.Id = Attendences.ModuleTypeId join Students on Students.Id = Attendences.StudentId join TimeTables on TimeTables.Id = Attendences.TimeTableId"; //WHERE Attendences.Date BETWEEN '" + startWeek.ToString("dd/MM/yyyy") + "' and '" + endWeek.ToString("dd/MM/yyyy") + "'
            var dt1 = db.List(sql);
            var model = new Attendence().List(dt1);
            return View(model);
        }

        public ActionResult MonthlyStudent(int? StudentId)
        {
            var dateTime = DateTime.Now;
            int year = dateTime.Date.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            CultureInfo cul = CultureInfo.CurrentCulture;
            int week = cul.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int days = (week - 1) * 7;
            DateTime dt = firstDay.AddDays(days);
            DayOfWeek dayWeek = dt.DayOfWeek;
            DateTime startWeek = dt.AddDays(-(int)dayWeek);
            DateTime endWeek = startWeek.AddDays(6);

            string sql = "Select * from Attendences join Teachers on Teachers.Id = Attendences.TeacherId join Courses on Courses.Id = Attendences.CourseId join ModuleTypes on ModuleTypes.Id = Attendences.ModuleTypeId join Students on Students.Id = Attendences.StudentId join TimeTables on TimeTables.Id = Attendences.TimeTableId WHERE Attendences.Date LIKE '__/" + dateTime.ToString("MM/yyyy") + "%' AND Students.Id = '" + StudentId + "'";
            var dt1 = db.List(sql);
            var model = new Attendence().List(dt1);
            return View(model);
        }

        public ActionResult Monthly()
        {
            var dateTime = DateTime.Now;
            int year = dateTime.Date.Year;
            DateTime firstDay = new DateTime(year, 1, 1);
            CultureInfo cul = CultureInfo.CurrentCulture;
            int week = cul.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int days = (week - 1) * 7;
            DateTime dt = firstDay.AddDays(days);
            DayOfWeek dayWeek = dt.DayOfWeek;
            DateTime startWeek = dt.AddDays(-(int)dayWeek);
            DateTime endWeek = startWeek.AddDays(6);

            string sql = "Select * from Attendences join Teachers on Teachers.Id = Attendences.TeacherId join Courses on Courses.Id = Attendences.CourseId join ModuleTypes on ModuleTypes.Id = Attendences.ModuleTypeId join Students on Students.Id = Attendences.StudentId join TimeTables on TimeTables.Id = Attendences.TimeTableId WHERE Attendences.Date LIKE '__/" + dateTime.ToString("MM/yyyy") + "%'";
            var dt1 = db.List(sql);
            var model = new Attendence().List(dt1);
            return View(model);
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
