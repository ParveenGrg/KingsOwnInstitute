﻿using KingsOwnInstitute.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.ViewModels
{
    public class NewRegistrationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Attendee")]
        [ForeignKey("Attendee")]
        public int AttendeeId { get; set; }
        [ForeignKey("Seminar")]
        [Display(Name = "Seminar")]
        public int SeminarId { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        public virtual Attendee Attendee { get; set; }
        public virtual Seminar Seminar { get; set; }
    }
}
