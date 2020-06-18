using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DropDownWithSearch.Models;
using DropDownWithSearch.Models.ViewModel;

namespace DropDownWithSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestContext _db;

        public HomeController(TestContext db)
        {
            _db= db;
        }

        public IActionResult Index(int institution, int department)
        {
            ViewModel mymodel = new ViewModel();

            var emplist = from rec in _db.EmployeeList select rec;
            if (!(institution == 0))
            {
                emplist = emplist.Where(e => e.InsId == institution);
            }
            if (!(department == 0))
            {
                emplist = emplist.Where(e => e.DeptId == department);
            }
            mymodel.employeeList = emplist;
            mymodel.department = _db.Department.ToList();
            mymodel.institution=_db.Institution.ToList();

            return View(mymodel);
        }
    }
}
