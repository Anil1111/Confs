using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public  class ConferenceEmployee
    {
        public int idEmp { get; set; }
        public int idConference { get; set; }
        public Conference conference { get; set; }
        public Employee employee { get; set; }
        public override string ToString()
        {
            return base.ToString() + "IDEMPLOYEE " + idEmp + "IDCONFERENCE " + idConference;
        }
    }
}
