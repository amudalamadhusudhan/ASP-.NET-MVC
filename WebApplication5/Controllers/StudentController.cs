using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class StudentController : Controller
    {
        static IList<Student> studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
            };
        public ActionResult Index()
        {
            return View(studentList);
        }
            [HttpPost]
            public ActionResult PostAction() // handles POST requests by default
            {
                return View("Index");
            }


            [HttpPut]
            public ActionResult PutAction() // handles PUT requests by default
            {
                return View("Index");
            }

            [HttpDelete]
            public ActionResult DeleteAction(Student studentid) // handles DELETE requests by default
            {
                return View("Index"); 
            }

            [HttpHead]
            public ActionResult HeadAction() // handles HEAD requests by default
            {
                return View("Index");
            }

            [HttpOptions]
            public ActionResult OptionsAction() // handles OPTION requests by default
            {
                return View("Index");
            }

            [HttpPatch]
            public ActionResult PatchAction() // handles PATCH requests by default
            {
                return View("Index");
            }
        }
    
}