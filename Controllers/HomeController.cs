using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FactoryWebSite.Models;

namespace FactoryWebSite.Controllers
{
    public class HomeController : Controller
    {
        HomeBL homeBL = new HomeBL();
        
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult HomePage()
        {
             if (Session["authenticated"]!=null)
            {
                ViewBag.username = Session["name"];
                return View("HomeMenu");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            

        }


        [HttpPost]
        public ActionResult GetLoginData(string usN, string pwd)
        {
            
            bool isAuthenticated = homeBL.Authentic(usN, pwd);
            var user = homeBL.GetUserByLogin(usN, pwd);
            var currentDate = DateTime.Today.ToString();

           // loging in
            if(user.ActionsCounter>0 &&isAuthenticated==true)
            {
                Session["authenticated"] = true;
                Session["numOfActions"] = user.ActionsCounter;
                Session["name"] = user.FullName;
                Session["id"] = user.ID;
                
                return RedirectToAction("HomePage", "Home");
            }else if(user.ActionsCounter==0&& isAuthenticated == true&&currentDate==(currentDate+1))
            {
                homeBL.ResetActions(user.ID);
                
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }


      
        

          

       

        
    }
}