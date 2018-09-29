using Data.Configuration;
using Data.Custom_Convention;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   
    public class PIContext : DbContext
    {

        public PIContext() : base("Name=PI")
        {


        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Add(new DateTime2Convention());
            modelBuilder.Configurations.Add(new ConferenceEmpConfig());
            //modelBuilder.Configurations.Add(new OfferReservation());
        }

        public DbSet<Conference> Conference { get; set; }
        public DbSet<Employee> Employee { get; set; }

    }
}
