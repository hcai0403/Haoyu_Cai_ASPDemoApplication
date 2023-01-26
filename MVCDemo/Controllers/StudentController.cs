using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter() {
            return View("EnterStudent");
        
        }
        [HttpPost]
        public ActionResult Submit() {
            Student obj = new Student();
            obj.StudentRollNumber = Request.Form["StudentRollno"];
            obj.StudentName = Request.Form["StudentName"];
            obj.StudentStd = Request.Form["StudentStd"];
            obj.StudentDIV = Request.Form["StudentDiv"];

            return View("Student", obj);
        }
    }
}