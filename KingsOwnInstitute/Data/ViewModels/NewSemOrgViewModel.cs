using KingsOwnInstitute.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data.ViewModels
{
    public class NewSemOrgViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Seminar")]
        public int SeminarId { get; set; }
        [Display(Name = "Organizer")]
        public int OrganizerId { get; set; }
        public Seminar Seminar { get; set; }
        public Organizer Organizer { get; set; }
    }
}
