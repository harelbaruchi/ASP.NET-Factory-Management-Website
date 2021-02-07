using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FactoryWebSite.Models;

namespace FactoryWebSite.Controllers
{
    public class EmployeesController : Controller
    {
        HomeBL homeBL = new HomeBL();
         EmployeeBL employeeBL = new EmployeeBL();
        ShiftBL shiftBL = new ShiftBL();
        // GET: Department
        public ActionResult Employees()
        {

           
            if (Session["authenticated"] != null&& (int)Session["numOfActions"]>0)
            {

                var empList = employeeBL.GetEmployees();
                ViewBag.employees = empList;
                ViewBag.username = Session["name"];
                homeBL.ReduceActions((int)Session["id"]);
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult EditEmp(int ID)
        {
            ViewBag.username = Session["name"];
            var employee = employeeBL.GetEmployee(ID);
            return View("EditEmp", employee);
        }
        [HttpPost]
        public ActionResult GetUpdatedEmp(employee emp)
        {
            employeeBL.EditEmp(emp);
            return RedirectToAction("Employees");
        }

        public ActionResult GetNewShift(employee emp,shift shf)
        {
            employeeBL.ShiftToEmployee(shf, emp);
            return RedirectToAction("Employees");
        }

        public ActionResult AddShiftToEmployee(int ID)
        {
            var shiftList = shiftBL.GetShifts();
            ViewBag.shifts = shiftList;
            var emp = employeeBL.GetEmployee(ID);
            ViewBag.username = Session["name"];
            return View("AddShift",emp);
        }


        public ActionResult SearchEmp()
        {
            return View("SearchEmployee"); 
        }
        //receiving search terms from the user  
        [HttpPost]
        public ActionResult GetSearchTerms(string srchTerm)
        {
            var result = employeeBL.Search(srchTerm);
            ViewBag.Employees = result;
            return View("Employees");
        }

        public ActionResult DeleteEmp(int ID)
        {
            employeeBL.DeleteById(ID);
            return RedirectToAction("index");
        }
    }
}