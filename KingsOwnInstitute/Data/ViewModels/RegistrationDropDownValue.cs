using KingsOwnInstitute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.ViewModels
{
    public class RegistrationDropDownValue
    {
        public RegistrationDropDownValue()
        {
            Seminars = new List<Seminar>();
            Attendees = new List<Attendee>();
        }
        public List<Seminar> Seminars { get; set; }
        public List<Attendee> Attendees { get; set; }
    }
}
