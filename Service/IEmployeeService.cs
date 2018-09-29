using Domain.Entities;
using Services.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IEmployeeService: IService<Employee>
    {
         IEnumerable<Employee> getAll();
        IEnumerable<Employee> sortBySalary();
    }
}
