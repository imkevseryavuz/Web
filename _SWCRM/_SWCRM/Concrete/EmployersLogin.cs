using _SWCRM.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SWCRM.Models;

namespace _SWCRM.Concrete
{
    public class EmployersLogin : IDataBusiness<Employer>
    {
        public void DeleteData(Employer model, int Id)
        {
            throw new NotImplementedException();
        }
        public Employer EmployerLogin(string userName, string password)
        {
            using (SWCRMEntities db = new SWCRMEntities())
            {
                return db.Employers.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
            }
        }
        public void InsertData(Employer model)
        {
            throw new NotImplementedException();
        }

        public List<Employer> ListData()
        {
            throw new NotImplementedException();
        }

        public Employer SelectData(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Employer model)
        {
            throw new NotImplementedException();
        }
    }
}