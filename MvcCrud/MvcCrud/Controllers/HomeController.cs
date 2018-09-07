using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrud.Models;

namespace MvcCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context=new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            var employees = _context.Employees.OrderBy(i => i.FirstName).ToList();
            return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            var emp = _context.Employees.Where(i => i.Id == id).FirstOrDefault();
            return View(emp);
        }

        [HttpPost]
        public ActionResult Save(Employee emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (emp.Id == 0)
                {
                    var recordInDb = _context.Employees.Single(i => i.Id == emp.Id);
                    if (recordInDb != null)
                    {
                        recordInDb.FirstName = emp.FirstName;
                        recordInDb.LastName = emp.LastName;
                        recordInDb.EmailId = emp.EmailId;
                        recordInDb.City = emp.City;
                        recordInDb.Country = emp.Country;
                    }
                }
                else
                {
                    _context.Employees.Add(emp);
                }

                _context.SaveChanges();
                status = true;
            }
            return new JsonResult{Data = new {status}};
        }

        [HttpDelete]//for Confirmation of delete
        public ActionResult Delete(int id)
        {
            var recordInDb = _context.Employees.Where(i => i.Id == id).FirstOrDefault();
            if (recordInDb != null)
            {
                return View(recordInDb);
            }
            else
            {
                return HttpNotFound(); 
            }
        }

        [HttpDelete]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;
           var recordInDb=_context.Employees.Where(i => i.Id == id).FirstOrDefault();
            if (recordInDb != null)
            {
                _context.Employees.Remove(recordInDb);
                _context.SaveChanges();
                status=true;  
            }
            return new JsonResult{Data = new {status}};

        }
    }
}