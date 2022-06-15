using KingsOwnInstitute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.ViewModels
{
    public class SemOrgDropDownValue
    {
        public SemOrgDropDownValue()
        {
            Seminars = new List<Seminar>();
            Organizers = new List<Organizer>();
        }
        public List<Seminar> Seminars { get; set; }
        public List<Organizer> Organizers { get; set; }
    }
}
