using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FactoryWebSite.Models;

namespace FactoryWebSite.Controllers
{
    
    public class ShiftController : Controller
    {
        
        ShiftBL shiftBL = new ShiftBL();
        HomeBL homeBL = new HomeBL();

        // GET: Shift
        public ActionResult Shifts()
        {
            if (Session["authenticated"] != null && (int)Session["numOfActions"] > 0)
            {
                ViewBag.username = Session["name"];
                homeBL.ReduceUserActions((int)Session["id"]);
                var shiftList = shiftBL.GetShifts();
                ViewBag.Shifts = shiftList;
                return View();

             
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        public ActionResult AddShift()
        {
            ViewBag.username = Session["name"];
            return View("NewShift");
        }

        public ActionResult GetNewShift(shift sh)
        {
            shiftBL.AddShift(sh);
            return RedirectToAction("Shifts");
        }


    }
}