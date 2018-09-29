using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class ConferenceEmpConfig : EntityTypeConfiguration<ConferenceEmployee>
    {
        public ConferenceEmpConfig()
        {
            HasKey(t => new { t.idEmp, t.idConference});
            HasRequired(x => x.employee).WithMany(x => x.EmpConf).HasForeignKey(x => x.idEmp).WillCascadeOnDelete();
            HasRequired(x => x.conference).WithMany(x => x.ConfEmp).HasForeignKey(x => x.idConference).WillCascadeOnDelete();
        }
    }
}
