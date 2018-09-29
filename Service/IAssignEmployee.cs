using Domain.Entities;
using Services.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
  public  interface IAssignEmployee : IService<ConferenceEmployee>
    {
        IEnumerable<ConferenceEmployee> getAll();
        ConferenceEmployee getByIds(int idConf, int idEmp);
        ICollection<Employee> ListEmpByConf(int idConf);
        int NumberEmplByConTypeFacultative();
        int NumberEmplByConTypeObligatoire();
    }
}
