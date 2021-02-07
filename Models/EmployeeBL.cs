using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryWebSite.Models
{
    public class EmployeeBL
    {
         FactoryDBEntities3 db = new FactoryDBEntities3();
        ShiftBL shiftBL = new ShiftBL();
        public List<employee> GetEmployees()
        {


            return db.employees.ToList();
            //var result = from Emp in db.employees
            //             join dep in db.departments on Emp.DepID equals dep.ID
            //             join Em_shf in db.EmployeeShifts on Emp.ID equals Em_shf.EmployeeID
            //             join Shift in db.shifts on Em_shf.ShiftID
            //              equals Shift.ID

                        
            //             select new EmployeeD
            //             {
            //                 ID = Emp.ID,
            //                 FirstName = Emp.FirstName,
            //                 LastName = Emp.LastName,
            //                 YearStarted = Emp.YearStarted,
            //                 DepID = Emp.DepID,
            //                 ShiftDate=(DateTime)Shift.ShiftDate,
            //                StartShift= (int)Shift.StartTime,
            //                EndShift= (int)Shift.EndTime

            //             };

            
        }


        public employee GetEmployee(int ID)
        {
            return db.employees.Where(x => x.ID == ID).First();
        }

        


        public void EditEmp(employee emp)
        {
            var empToUpdate = db.employees.Where(x => x.ID == emp.ID).First();
            empToUpdate.LastName = emp.LastName;
            empToUpdate.FirstName = emp.FirstName;
            empToUpdate.YearStarted = emp.YearStarted;
            empToUpdate.DepID = emp.DepID;
            db.SaveChanges();

        }

        public void DeleteById(int ID)
        {
            var empToDelete = db.employees.Where(x => x.ID == ID).First();
            db.employees.Remove(empToDelete);
            db.SaveChanges();
        }

        public List<employee> Search(string phrase)
        {
            var emp = GetEmployees();
            return emp.Where(x => x.FirstName.Contains(phrase) || x.LastName.Contains(phrase)).ToList();
        } 

        public void ShiftToEmployee(shift shf,employee emp)
        {
            //var shiftID = shf.ID;
            //var empID = emp.ID;
            var empshift = new EmployeeShift();
            empshift.ShiftID = shf.ID;
            empshift.EmployeeID = emp.ID;
            db.EmployeeShifts.Add(empshift);
            db.SaveChanges();

        }


    }
    
}