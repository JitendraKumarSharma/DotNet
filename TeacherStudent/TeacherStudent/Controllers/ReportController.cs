using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeacherStudent.ModelClasses;
using System.Data.Entity;

namespace TeacherStudent.Controllers
{
    public class ReportController : Controller
    {
        private SchoolContext db;
        public ReportController(SchoolContext db)
        {
            this.db = db;
        }
        // GET: Report
        public ActionResult Index()
        {
            //ViewBag.Data=db.Students.Include()
            var stu = db.Students.Include("Teacher").ToList();
            var stu1 = db.Students.Select(x => new { x.Teacher.TeacherName, x.Teacher.Address });
            var dd = db.Students.Include(x => x.Teacher).ToList(); // Works when use System.Data.Entity;
            //    .Select(item =>
            //new
            //{
            //    StudentName = item.Name,
            //    Class = item.Class,
            //    TeacherName = item.Teacher.TeacherName,
            //    TeacherAddress = item.Teacher.Address

            //});

            return View(stu.ToList());
        }
    }
}