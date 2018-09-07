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
            return Json(new {data = employees}, JsonRequestBehavior.AllowGet);
        }
    }
}