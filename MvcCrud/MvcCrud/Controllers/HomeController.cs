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
            var emp = _context.Employees.FirstOrDefault(i => i.Id == id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Save(Employee emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                if (emp.Id > 0)
                {
                    //Edit 
                    var v = _context.Employees.Where(a => a.Id == emp.Id).FirstOrDefault();
                    if (v != null)
                    {
                        v.FirstName = emp.FirstName;
                        v.LastName = emp.LastName;
                        v.EmailId = emp.EmailId;
                        v.City = emp.City;
                        v.Country = emp.Country;
                    }
                }
                else
                {
                    //Save
                    _context.Employees.Add(emp);
                }

                _context.SaveChanges();
                status = true;
            }

            return new JsonResult {Data = new {status = status}};
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var recordInDb = _context.Employees.FirstOrDefault(i => i.Id == id);
            if (recordInDb != null)
            {
                return View(recordInDb);
            }

            return HttpNotFound();
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;
           
          
                var v = _context.Employees.FirstOrDefault(a => a.Id == id);
                if (v != null)
                {
                    _context.Employees.Remove(v);
                    _context.SaveChanges();
                    status = true;
                }
        
            return new JsonResult { Data = new { status = status} };
        }
    }
}