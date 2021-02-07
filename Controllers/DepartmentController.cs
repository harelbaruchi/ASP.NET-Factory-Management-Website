using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FactoryWebSite.Models;

namespace FactoryWebSite.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentBL departmentBL = new DepartmentBL();
        HomeBL homeBL = new HomeBL();
        // GET: Department
        public ActionResult Departments()
        {
            if (Session["authenticated"] != null&& (int)Session["numOfActions"] > 0)
            {
                ViewBag.username = Session["name"];
                homeBL.ReduceActions((int)Session["id"]);
                var depList = departmentBL.GetDepartments();
                ViewBag.departments = depList;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult EditDep(int ID)
        {
            ViewBag.username = Session["name"];
            var dep = departmentBL.GetDepartment(ID);
            return View("EditDep", dep);
        }

        [HttpPost]
        public ActionResult GetUpdatedDep(department dep)
        {
            departmentBL.EditDep(dep);
            return RedirectToAction("Departments");
        }

    }
}