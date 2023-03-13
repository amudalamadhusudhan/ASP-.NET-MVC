using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        MVCcrudDB1Context _context1 = new MVCcrudDB1Context();
        public ActionResult Index()
        {
            var elist = _context1.Employees.ToList();
            return View(elist);
        }
        [HttpPost]
        public ActionResult Index(Employee model)
        {
            ViewBag.Id = model.EmployeeId;
            ViewBag.Name = model.Employeename;
            ViewBag.DepT = model.Employeedepartment_;
            ViewBag.Salary=model.Salary;
            ViewBag.Designation=model.Designation;
            ViewBag.Managerid = model.ManagerId;
            return View("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            try
            {

                _context1.Employees.Add(model);
                _context1.SaveChanges();
                TempData["Message"] = "sucussfully added EMPLOYEElist";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Employee id already existed in the system");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context1.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(Employee model)
        {
             var data = _context1.Employees.Where(x => x.EmployeeId == model.EmployeeId).FirstOrDefault();
            if (data != null)
            {
                data.EmployeeId=model.EmployeeId;   
                data.Employeename = model.Employeename;
                data.Employeedepartment_ = model.Employeedepartment_;
                data.Salary = model.Salary;
                data.Designation = model.Designation;
                data.ManagerId=model.ManagerId;
                TempData["Messages"] = "Student list created successfully.";
                _context1.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = _context1.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult Delete(Employee model)
        {
            var data = _context1.Employees.Where(x => x.EmployeeId == model.EmployeeId).FirstOrDefault();
            
                _context1.Employees.Remove(data);
                _context1.SaveChanges();
                return RedirectToAction("Index");
            
           
        }
        [HttpGet]
        public ActionResult Details(int id)
        {

            var data = _context1.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }

    }
}