using Data.Infrastructure;
using Domain.Entities;
using Services.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public  class EmployeeService: Service<Employee>, IEmployeeService
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork ut = new UnitOfWork(dbf);

        public EmployeeService():base(ut)
        {

        }

        public IEnumerable<Employee> getAll()
        {
            return ut.getRepository<Employee>().GetMany(x => x.EmployeeID != null);
        }
          public IEnumerable<Employee> sortBySalary()
        {
            return ut.getRepository<Employee>().GetMany(x => x.EmployeeID != null).OrderByDescending(x => x.Salary);
         }
    }

  
}
