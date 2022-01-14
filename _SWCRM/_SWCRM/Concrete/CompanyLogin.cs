using _SWCRM.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SWCRM.Models;
namespace _SWCRM.Concrete
{
    public class CompanyLogin : IDataBusiness<Employee>
    {
        public void DeleteData(Employee model, int Id)
        {
            throw new NotImplementedException();
        }

        public void InsertData(Employee model)
        {
            throw new NotImplementedException();
        }

        public List<Employee> ListData()
        {
            throw new NotImplementedException();
        }

        public Employee Login(string userName, string password)
        {
            using (SWCRMEntities db = new SWCRMEntities())
            {
                return db.Employees.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
            }
        }

        public Employee SelectData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}