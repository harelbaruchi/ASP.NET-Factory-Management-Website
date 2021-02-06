using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryWebSite.Models
{

    public class ShiftBL
    {
        FactoryDBEntities3 db = new FactoryDBEntities3();

        public List<shift> GetShifts()
        {
            return db.shifts.ToList();
        }

        public void AddShift(shift sh)
        {
            db.shifts.Add(sh);
            db.SaveChanges();

        }




    }
}