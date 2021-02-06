using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryWebSite.Models
{
    public class DepartmentBL
    {
        FactoryDBEntities3 db = new FactoryDBEntities3();

        public List<department> GetDepartments()
        {
            return db.departments.ToList();
        }

        public department GetDepartment(int ID)
        {
            return db.departments.Where(x => x.ID == ID).First();
        }

        public void UpdateDep(department dep)
        {
            var depToUpdate = db.departments.Where(x => x.ID == dep.ID).FirstOrDefault();
            depToUpdate.ID = dep.ID;
            depToUpdate.DepName = dep.DepName;
            depToUpdate.Manager = dep.Manager;
            db.SaveChanges();

        }

    }
}