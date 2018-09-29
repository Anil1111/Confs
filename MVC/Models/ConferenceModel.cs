using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ConferenceModel
    {
       
        public string subject { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateConference { get; set; }

        public string lieu { get; set; }
        public int rate { get; set; }
        public type typeConference { get; set; }
    }
}