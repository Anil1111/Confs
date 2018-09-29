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
    public class AssignEmployee : Service<ConferenceEmployee>, IAssignEmployee
    {

        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork ut = new UnitOfWork(dbf);

        public AssignEmployee():base(ut)
        {

        }
        public IEnumerable<ConferenceEmployee> getAll()
        {
            return ut.getRepository<ConferenceEmployee>().GetMany(x => x.idConference != null);
        }

        /********************************************************************/
        public ConferenceEmployee getByIds(int idConf, int idEmp)
        {
            ConferenceEmployee CE = null;
               var x = ut.getRepository<ConferenceEmployee>().GetMany(c => c.idConference == idConf);
            foreach (var item in x)
            {
                if (item.idEmp==idEmp)
                {
                    CE = item;
                    
                }
            }

            return CE;
        }

        /*****************************************************************************/
        public ICollection<Employee> ListEmpByConf(int idConf)
        {
            EmployeeService e = new EmployeeService();
            Employee empToAdd = null;
            ICollection<Employee> listEmpToFill = new List<Employee>();
            var listEmp= ut.getRepository<ConferenceEmployee>().GetMany(x => x.idConference == idConf).Select(x => x.idEmp).ToList();
            foreach (var item in listEmp)
            {
               empToAdd = e.GetById(item);
                listEmpToFill.Add(empToAdd);
            }
            return listEmpToFill;
        }
        /*****************************************************************************/
        public int NumberEmplByConTypeFacultative()
        {
            int a = 0;
            var y = ut.getRepository<Conference>().GetMany(x => x.typeConference == type.Facultative);
            var z = getAll();
            foreach (var itemConfEmp in z.ToArray())
            {
                foreach (var itemConf in y.ToArray())
                {
                    if (itemConf.idConference == itemConfEmp.idConference)
                    {
                        a++;
                    }
                }
            }
            return a;
        }

        public int NumberEmplByConTypeObligatoire()
        {
            int a = 0;
            var y = ut.getRepository<Conference>().GetMany(x => x.typeConference == type.Obligatoire);
            var z = getAll();
            foreach (var itemConfEmp in z.ToArray())
            {
                foreach (var itemConf in y.ToArray())
                {
                    if (itemConf.idConference == itemConfEmp.idConference)
                    {
                        a++;
                    }
                }
            }
            return a;
        }

    }
}
