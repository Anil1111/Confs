using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        public long CIN { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateNaissance { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Speciality { get; set; }

        [Range(0, float.MaxValue)]
        public float Salary { get; set; }
        
        //navigation props
        public virtual ICollection<ConferenceEmployee> EmpConf { get; set; }
    }
}
