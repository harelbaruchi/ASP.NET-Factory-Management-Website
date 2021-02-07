using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryWebSite.Models
{
    public class HomeBL
    {
        FactoryDBEntities3 db = new FactoryDBEntities3();
       
        public bool Authentic(string userName, string passWord)
        {
            
            foreach(var u in db.users)
            {
                //I allowed every user to do  actions
                if(u.UserName== userName && u.Pwd== passWord)
                {
                  
                    
                    return true;
                }
            }
            return false;
           
        }

        //get the user as an object 
        public user GetUserByLogin(string userName, string passWord)
        {
            user result = db.users.Where(x => x.UserName == userName && x.Pwd == passWord).First();

            return result;
        }

        //reduce the user actions count

        public void ReduceActions(int userID)
        {
            user u = db.users.Where(x => x.ID == userID).First();
            int num = u.ActionsCounter - 1;
            u.ActionsCounter = num;
            db.SaveChanges();
        }

        public void ResetActions(int userID)
        {
            user u = db.users.Where(x => x.ID == userID).First();
            u.ActionsCounter = 5;
            db.SaveChanges();
        }


    }
}