using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryWebSite.Models
{
    public class HomeBL
    {
        FactoryDBEntities3 db = new FactoryDBEntities3();
       
        public bool IsAuthenticated(string usN, string pwd)
        {
            
            foreach(var u in db.users)
            {
                //I allowed every user to do  actions
                if(u.UserName==usN && u.Pwd==pwd)
                {
                  
                    
                    return true;
                }
            }
            return false;
           
        }

        //get the user as an object 
        public user GetUser(string userName, string pwd)
        {
            user result = db.users.Where(x => x.UserName == userName && x.Pwd == pwd).First();

            return result;
        }

        //reduce the user actions count

        public void ReduceUserActions(int userID)
        {
            user u = db.users.Where(x => x.ID == userID).First();
            int num = u.ActionsCounter - 1;
            u.ActionsCounter = num;
            db.SaveChanges();
        }

        public void ResetUserNumOfAction(int userID)
        {
            user u = db.users.Where(x => x.ID == userID).First();
            u.ActionsCounter = 5;
            db.SaveChanges();
        }


    }
}