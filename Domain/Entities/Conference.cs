using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public  class Conference
    {
        [Key]
        public int idConference { get; set; }
        public string subject { get; set; }
        public DateTime dateConference { get; set; }

        public string lieu { get; set; }
        public int rate { get; set; }

        public type typeConference { get; set; }
        //navigations props
        public virtual ICollection<ConferenceEmployee> ConfEmp { get; set; }
    }
    public enum type
    {
        Facultative,
        Obligatoire
    }
 
}
