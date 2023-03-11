using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        MVCcrudDBContext _context = new MVCcrudDBContext();
        public ActionResult Index()
        {
            var studentList = _context.students.ToList();
            return View(studentList);
        }
        [HttpPost]
        public ActionResult Index(student model)
        {
            ViewBag.Id = model.studentId;
            ViewBag.Name = model.studentname;
            return View("Index");
        }
        [HttpGet]
        public ActionResult Create() {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(student model) {
             try
            {
                
                _context.students.Add(model);
                _context.SaveChanges();
                TempData["Message"] = "sucussfully added studentlist";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "student id already existed in the system"); 
            }
            return View();
        }

        [HttpGet] 
        public ActionResult Edit(int id)
        {
            var data = _context.students.Where(x => x.studentId == id).FirstOrDefault();
            return View(data);

        }
        [HttpPost]  
        public ActionResult Edit(student model) 
        {
         var data = _context.students.Where(x => x.studentId == model.studentId).FirstOrDefault();
            if(data!= null)
            {
                data.studentname=model.studentname;
                data.age=model.age;
                TempData["Message"] = "Student list created successfully.";
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
             
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = _context.students.Where(x => x.studentId == id).FirstOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult Delete(student model)
        {
            var data = _context.students.Where(x => x.studentId == model.studentId).FirstOrDefault();

            _context.students.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id) {

            var data = _context.students.Where(x => x.studentId == id).FirstOrDefault();
             return View(data);
        }

    }
}